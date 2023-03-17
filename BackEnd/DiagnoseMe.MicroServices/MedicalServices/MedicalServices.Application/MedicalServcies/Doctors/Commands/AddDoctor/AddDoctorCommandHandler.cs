using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Application.MedicalServcies.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctor;


public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IClinicRepository _clinicRepository;
    public AddDoctorCommandHandler(
        IDoctorRepository doctorRepository,
        IClinicRepository clinicRepository)

    {
        _doctorRepository = doctorRepository;
        _clinicRepository = clinicRepository;
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
        var user = (await _doctorRepository.Get(
            predicate: u => u.Id == command.UserId,
            include: "User")).
            FirstOrDefault()!.User;
        
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