using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    private readonly IClinicRepository _clinicRepository;

    public UpdateDoctorCommandHandler(
        IDoctorRepository doctorRepository,
        IMessageQueueManager messageQueueManager,
        IClinicRepository clinicRepository)
    {
        _doctorRepository = doctorRepository;
        _messageQueueManager = messageQueueManager;
        _clinicRepository = clinicRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = (await _doctorRepository.Get(
            predicate: x => x.Id == command.DoctorId
        )).FirstOrDefault();
        if (doctor == null)
            return Errors.Doctor.NotFound;
        
        doctor.Bio = command.Bio;
        doctor.Title = command.Title;
        if (command.ClinicId != null)
        {
            var clinic = (await _clinicRepository.Get(
                predicate: x => x.Id == command.ClinicId
            )).FirstOrDefault();
            if (clinic == null)
                return Errors.Clinic.NotFound;
            doctor.Clinic = clinic;
            doctor.ClinicId = clinic.Id;
        }

        await _doctorRepository.Edit(doctor);
        if (await _doctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.UpdateFailed;
        
        _messageQueueManager.PublishUpdatedDoctor(new RMQUpdateDoctorResponse
        (
            Id: doctor.Id!,
            Specialization: doctor.Clinic!.Specialization,
            Rating: doctor!.AverageRate
        ));
        return new CommandResponse(
            Success: true,
            Message: "Doctor updated successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );
    }
}