using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdatePricePerSession;

public class UpdatePricePerSessionCommandHandler : IRequestHandler<UpdatePricePerSessionCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;

    public UpdatePricePerSessionCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdatePricePerSessionCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(command.doctorId);

        if (doctor is null)
            return Errors.Doctor.NotFound;

        doctor.PricePerSession = command.price;

        await _doctorRepository.Edit(doctor);
        if ( await _doctorRepository.SaveAsync() == 0)
            return Errors.Doctor.UpdateFailed;

        return new CommandResponse(
            Success: true,
            Message: $"Price per session for doctor with id {doctor.Id} was updated successfully to {doctor.PricePerSession}",
            Path : null!
        );
    }
}