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
using Microsoft.AspNetCore.Http;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.AddCheck;

public class AddCheckCommandHandler : IRequestHandler<AddCheckCommand, ErrorOr<CommandResponse>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ICheckFileRepository _fileRepository;
    private readonly IMessageQueueManager _messageQueueManager;


    public AddCheckCommandHandler(
        ICheckRepository checkRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        ICheckFileRepository fileRepository,
        IMapper mapper,
        IMessageQueueManager messageQueueManager)
    {
        _checkRepository = checkRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _fileRepository = fileRepository;
        _mapper = mapper;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddCheckCommand command, CancellationToken cancellationToken)
    {   

        if((command.UserId == command.PatientId && !command.Roles.Contains(Roles.User)) ||
            (command.UserId == command.DoctorId && !command.Roles.Contains(Roles.Doctor)) ||
            command.UserId != command.PatientId || command.UserId != command.DoctorId)
            return Errors.User.YouCanNotDoThis;

        var patient = await _patientRepository.GetByIdAsync(command.PatientId);
        if (patient is null)
            return Errors.Patient.NotFound;

        var check = _mapper.Map<Check>(command);
        check.Id = Guid.NewGuid().ToString();
        check.Patient = patient;
        if (command.DoctorId is not null)
        {
            var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);
            if (doctor is null)
                return Errors.Doctor.NotFound;
            check.Doctor = doctor;
        }

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

        check.CheckFiles = checkFiles;
        await _checkRepository.AddAsync(check);
        if(await _checkRepository.SaveAsync() == 0)
            return Errors.Check.AddFailed;
        _messageQueueManager.PublishFile(rMQFilesResponse);
        return new CommandResponse(
            Success: true,
            Message: "Check added successfully.",
            Path: $"checks/{check.Id}"
        );
    }
}