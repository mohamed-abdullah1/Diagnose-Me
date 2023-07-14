using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Helpers;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common;
using MedicalServices.Domain.Common.Errors;
using MedicalServices.Domain.Common.FIles;
using MedicalServices.Domain.Common.Roles;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.UpdateCheck;


public class UpdateCheckCommandHandler : IRequestHandler<UpdateCheckCommand, ErrorOr<CommandResponse>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly IMessageQueueManager _messageQueueManager;
    private readonly ICheckFileRepository _fileRepository;

    public UpdateCheckCommandHandler(
        ICheckRepository checkRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        ICheckFileRepository fileRepository,
        IMessageQueueManager messageQueueManager,
        IMapper mapper)
    {
        _checkRepository = checkRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _fileRepository = fileRepository;
        _messageQueueManager = messageQueueManager;
        _mapper = mapper;
    }
    
    public async Task<ErrorOr<CommandResponse>> Handle(UpdateCheckCommand command, CancellationToken cancellationToken)
    {
        var check = (await _checkRepository.Get(
            c => c.Id == command.Id,
            include: "Patient,Doctor,CheckFiles")).FirstOrDefault();

        if (check is null)
            return Errors.Check.NotFound;
        
        if (!((command.UserId == check.PatientId && !command.Roles.Contains(Roles.User)) ||
            (command.UserId == check.DoctorId && !command.Roles.Contains(Roles.Doctor)) ||
            command.UserId != check.PatientId || command.UserId != check.DoctorId ))
            return Errors.User.YouCanNotDoThis;

        check.Name = command.Name;
        check.Type = command.Type;
        check.Data = command.Data;
        check.Report = command.Report;

        var removedImages = check.CheckFiles.Where(f => command.RemovedImagesUrls.Contains(f.FileUrl)).ToList();
        check.CheckFiles = check.CheckFiles.Except(removedImages).ToList();
        
        List<CheckFile> checkFiles = new();
        var rMQFilesResponse = new List<RMQFileResponse>();
        var result = new ErrorOr<RMQFileResponse>();
        foreach (var file in command.Base64Files)
        {
            if (file.Type == AllowedFileTypes.Image)
            {
                result = FileHelper.CheckImage(
                    file.Data,
                    StaticPaths.ChecksDocuments );
                
                rMQFilesResponse.Add(result.Value);
            }
            else if (file.Type == AllowedFileTypes.Doc)
            {
                result = FileHelper.CheckDOC(
                    file.Data,
                    StaticPaths.ChecksDocuments );
                
                rMQFilesResponse.Add(result.Value);
            }
            else
            {
                return Errors.File.NotAllowed;
            }
            
            if (result.IsError)
                    return result.Errors;
            var checkFile = new CheckFile()
            {
                Id = Guid.NewGuid().ToString(),
                Check = check,
                FileUrl = result.Value.FilePath,
                Type = file.Type
            };
            checkFiles.Add(checkFile);
                await _fileRepository.AddAsync(checkFile);
        }
        check.CheckFiles.Concat(checkFiles);
        await _checkRepository.Edit(check);

        if(await _checkRepository.SaveAsync() == 0)
            return Errors.Check.UpdateFailed;
        
        _messageQueueManager.PublishFile(rMQFilesResponse);
        _messageQueueManager.DeleteFile(command.RemovedImagesUrls);
        return new CommandResponse(
            Success: true,
            Message: "Check updated successfully",
            Path: "Check"
        );
    }
}