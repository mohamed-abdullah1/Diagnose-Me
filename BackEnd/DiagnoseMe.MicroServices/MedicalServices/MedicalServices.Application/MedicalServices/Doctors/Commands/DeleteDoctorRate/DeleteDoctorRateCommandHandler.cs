using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.DeleteDoctorRate;


public class DeleteDoctorRateCommandHandler : IRequestHandler<DeleteDoctorRateCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRateRepository _doctorRateRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    private readonly IUnitOfWork _unitOfWork;    
    public DeleteDoctorRateCommandHandler(
        IDoctorRateRepository doctorRateRepository,
        IDoctorRepository doctorRepository,
        IMessageQueueManager messageQueueManager,
        IUnitOfWork unitOfWork)
    {
        _doctorRateRepository = doctorRateRepository;
        _doctorRepository = doctorRepository;
        _messageQueueManager = messageQueueManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteDoctorRateCommand command, CancellationToken cancellationToken)
    {
        var doctorRate = await _doctorRateRepository.GetByIdAsync(new {command.DoctorId, command.UserId});
        if (doctorRate is null)
            return Errors.Doctor.Rate.NotFound;
        
        var doctor =( await _doctorRepository.Get(
            predicate: x => x.Id == command.DoctorId,
            include: "Clinic")).
        FirstOrDefault();

        var doctorRatesCount = (await _doctorRateRepository.Get(
            predicate: x => x.DoctorId == command.DoctorId
        )).ToList().Count;
        if (doctor is null)
            return Errors.Doctor.NotFound;
        
        doctor.AverageRate = (doctor.AverageRate * doctorRatesCount - doctorRate.Rate) / (doctorRatesCount - 1);

        _doctorRateRepository.Remove(doctorRate);
        if (await _unitOfWork.Save() == 0)
            return Errors.Doctor.Rate.DeleteFailed;
        
        _messageQueueManager.PublishUpdatedDoctor(new RMQUpdateDoctorResponse(
            Id: doctor.Id!,
            Specialization: doctor.Clinic!.Specialization,
            Rating: doctor.AverageRate
        ));
        return new CommandResponse(
            Success: true,
            Message: "Doctor rate deleted successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );

    }
}