using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Authentication.Helpers;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;
using MedicalServices.Domain.Common.FIles;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.AddCheck;

public class AddCheckCommandHandler : IRequestHandler<AddCheckCommand, ErrorOr<CommandResponse>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly ICheckFileRepository _fileRepository;
    private readonly IFileHandler _fileHandler;
    private readonly IUnitOfWork _unitOfWork;


    public AddCheckCommandHandler(
        ICheckRepository checkRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        ICheckFileRepository fileRepository,
        IUnitOfWork unitOfWork,
        IFileHandler fileHandler,
        IMapper mapper)
    {
        _checkRepository = checkRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _fileRepository = fileRepository;
        _fileHandler = fileHandler;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddCheckCommand command, CancellationToken cancellationToken)
    {   
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

        await _checkRepository.AddAsync(check);
        if(await _unitOfWork.Save() == 0)
            return Errors.Check.AddFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Check added successfully.",
            Path: $"checks/{check.Id}"
        );
    }
}