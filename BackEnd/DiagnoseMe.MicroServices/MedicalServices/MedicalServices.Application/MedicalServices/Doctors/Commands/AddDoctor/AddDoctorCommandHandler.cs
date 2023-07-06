using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctor;


public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    public AddDoctorCommandHandler(
        IDoctorRepository doctorRepository,
        IClinicRepository clinicRepository,
        IUserRepository userRepository,
        IMessageQueueManager messageQueueManager)

    {
        _doctorRepository = doctorRepository;
        _clinicRepository = clinicRepository;
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddDoctorCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;

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

        doctor.Clinic = clinic;
        doctor.User = user;
        
        await _doctorRepository.AddAsync(doctor);
        _messageQueueManager.PublishUpdatedDoctor(new RMQUpdateDoctorResponse
        (
            Id: doctor.Id,
            Specialization: clinic.Specialization,
            Rating: 0
        ));
        
        if (await _doctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.AddFailed;

        return new CommandResponse(
            Success: true,
            Message: "Doctor added successfully.",
            Path: $"Doctors/{command.UserId}"
        );
    }
    
}