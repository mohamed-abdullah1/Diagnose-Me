using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctor;


public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IUserRepository _userRepository;
    public AddDoctorCommandHandler(
        IDoctorRepository doctorRepository,
        IClinicRepository clinicRepository,
        IUserRepository userRepository)

    {
        _doctorRepository = doctorRepository;
        _clinicRepository = clinicRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddDoctorCommand command, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetByIdAsync(command.ClinicId);
        if (clinic == null)
            return Errors.Clinic.NotFound;
        
        var doctor = new Doctor
        {
            Id = command.UserId,
            Title = command.Title,
            Bio = command.Bio,
            License = command.License,
            IsLicenseVerified = true,
            ClinicId = command.ClinicId
        };

        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;
        
        await _doctorRepository.AddAsync(doctor);

        if (await _doctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.AddFailed;

        return new CommandResponse(
            Success: true,
            Message: "Doctor added successfully.",
            Path: $"Doctors/{command.UserId}"
        );
    }
    
}