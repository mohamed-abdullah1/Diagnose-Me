using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctorRate;

public class UpdateDoctorRateCommandHandler : IRequestHandler<UpdateDoctorRateCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IDoctorRateRepository _doctorRateRepository;

    public UpdateDoctorRateCommandHandler(
        IUserRepository userRepository, 
        IDoctorRateRepository doctorRateRepository)
    {
        _userRepository = userRepository;
        _doctorRateRepository = doctorRateRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateDoctorRateCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;
        
        var doctorUser = (await _userRepository.Get(
            predicate: x => x.Id == command.DoctorId,
            include: "Doctor"
        )).FirstOrDefault();

        if (doctorUser is null || !doctorUser.IsDoctor)
            return Errors.Doctor.NotFound;

        var doctorRate = await _doctorRateRepository.GetByIdAsync(new {command.DoctorId, command.UserId});
        if (doctorRate is null)
            return Errors.Doctor.Rate.NotFound;

        var doctorRates = (await _doctorRateRepository.Get(
            predicate: x => x.DoctorId == command.DoctorId
        )).ToList();

        doctorUser.Doctor!.AverageRate = (doctorRates.Sum(x => x.Rate) - doctorRate.Rate + command.Rate) / (doctorRates.Count);

        doctorRate.Rate = command.Rate;
        doctorRate.Comment = command.Comment;

        await _doctorRateRepository.Edit(doctorRate);
        if (await _doctorRateRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.Rate.UpdateFailed;

        return new CommandResponse(
            Success: true,
            Message: "Doctor rate updated successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );
    }
}