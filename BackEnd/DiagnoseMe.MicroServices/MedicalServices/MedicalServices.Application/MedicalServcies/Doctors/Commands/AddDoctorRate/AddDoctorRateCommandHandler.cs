using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctorRate;

public class AddDoctorRateCommandHandler : IRequestHandler<AddDoctorRateCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IDoctorRateRepository _doctorRateRepository;

    public AddDoctorRateCommandHandler(
        IUserRepository userRepository,
        IDoctorRateRepository doctorRateRepository)
    {
        _userRepository = userRepository;
        _doctorRateRepository = doctorRateRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddDoctorRateCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _userRepository.GetByIdAsync(command.DoctorId);
        if (doctor == null || !doctor.IsDoctor)
            return Errors.Doctor.NotFound;
        
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;
        
        var doctorRate = new DoctorRate{
            Rate = command.Rate,
            Comment = command.Comment,
            UserId = command.UserId,
            DoctorId = command.DoctorId
        };

        await _doctorRateRepository.AddAsync(doctorRate);

        if (await _doctorRateRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.Rate.AddFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor rate added successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );
    }
}