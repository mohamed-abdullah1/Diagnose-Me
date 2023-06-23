using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctorRate;

public class AddDoctorRateCommandHandler : IRequestHandler<AddDoctorRateCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IDoctorRateRepository _doctorRateRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    private readonly IDoctorRepository _doctorRepository;

    public AddDoctorRateCommandHandler(
        IUserRepository userRepository,
        IDoctorRateRepository doctorRateRepository,
        IMessageQueueManager messageQueueManager,
        IDoctorRepository doctorRepository)
    {
        _userRepository = userRepository;
        _doctorRateRepository = doctorRateRepository;
        _messageQueueManager = messageQueueManager;
        _doctorRepository = doctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddDoctorRateCommand command, CancellationToken cancellationToken)
    {
        var doctor = ( await _doctorRepository.Get(
            predicate: x => x.Id == command.DoctorId,
            include: "Clinic")).
        FirstOrDefault();
    
        if (doctor == null)
            return Errors.Doctor.NotFound;
        
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;

        var doctorRates = (await _doctorRateRepository.Get(
            predicate: x => x.DoctorId == command.DoctorId
        )).ToList();

        var userDoctorRate = doctorRates.FirstOrDefault(x => x.UserId == command.UserId);

        if (userDoctorRate != null){
            doctor!.AverageRate = (doctorRates.Sum(x => x.Rate) - userDoctorRate.Rate + command.Rate) / (doctorRates.Count);
            userDoctorRate.Rate = command.Rate;
            userDoctorRate.Comment = command.Comment;
            await _doctorRateRepository.Edit(userDoctorRate);
        }
        else{
            doctor!.AverageRate = doctorRates.Count == 0
            ? command.Rate
            : (doctorRates.Sum(x => x.Rate) + command.Rate) / (doctorRates.Count + 1);
            userDoctorRate = new DoctorRate{
                Rate = command.Rate,
                Comment = command.Comment,
                UserId = command.UserId,
                DoctorId = command.DoctorId
            };

            userDoctorRate.User = user;
            userDoctorRate.Doctor = doctor;
            await _doctorRateRepository.AddAsync(userDoctorRate);
        }
        if (await _doctorRateRepository.SaveAsync() == 0)
            return Errors.Doctor.Rate.AddFailed;
        _messageQueueManager.PublishUpdatedDoctor(new RMQUpdateDoctorResponse
        (
            Id: doctor.Id!,
            Specialization: doctor.Clinic!.Specialization,
            Rating: doctor!.AverageRate
        ));
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor rate added successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );
    }
}