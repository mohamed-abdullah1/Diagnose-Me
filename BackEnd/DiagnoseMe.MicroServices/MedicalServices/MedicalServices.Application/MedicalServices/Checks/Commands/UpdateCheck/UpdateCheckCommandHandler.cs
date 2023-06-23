using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Authentication.Helpers;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServices.Common;
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
    private readonly ICheckFileRepository _fileRepository;
    private readonly IFileHandler _fileHandler;

    public UpdateCheckCommandHandler(
        ICheckRepository checkRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        ICheckFileRepository fileRepository,
        IFileHandler fileHandler,
        IMapper mapper)
    {
        _checkRepository = checkRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _fileRepository = fileRepository;
        _fileHandler = fileHandler;
        _mapper = mapper;
    }
    
    public async Task<ErrorOr<CommandResponse>> Handle(UpdateCheckCommand command, CancellationToken cancellationToken)
    {
        var check = (await _checkRepository.Get(
            c => c.Id == command.Id,
            include: "Patient,Doctor,CheckFiles")).FirstOrDefault();

        if (check is null)
            return Errors.Check.NotFound;
        
        if ((command.UserId == check.PatientId && !command.Roles.Contains(Roles.User)) ||
            (command.UserId == check.DoctorId && !command.Roles.Contains(Roles.Doctor)) ||
            command.UserId != check.PatientId && command.UserId != check.DoctorId )
            return Errors.User.YouCanNotDoThis;

        check.Name = command.Name;
        check.Type = command.Type;
        check.Data = command.Data;
        check.Report = command.Report;

        var removedImages = check.CheckFiles.Where(f => command.RemovedImagesUrls.Contains(f.FileUrl)).ToList();
        check.CheckFiles = check.CheckFiles.Except(removedImages).ToList();
        
        List<CheckFile> checkFiles = new();
        foreach (var file in command.Base64Files)
        {
            var result = new ErrorOr<string>();
            if (file.Type == AllowedFileTypes.Image)
            {
                result = SaveFile.SavePicture(file.Data, _fileHandler);
            }
            else if (file.Type == AllowedFileTypes.Doc)
            {
                result = SaveFile.SaveDoc(file.Data, _fileHandler);
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
                    FileUrl = result.Value,
                    Type = file.Type
                };
                await _fileRepository.AddAsync(checkFile);
        }
        check.CheckFiles.Concat(checkFiles);
        await _checkRepository.Edit(check);

        if(await _checkRepository.SaveAsync() == 0)
            return Errors.Check.UpdateFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Check updated successfully",
            Path: "Check"
        );
    }
}