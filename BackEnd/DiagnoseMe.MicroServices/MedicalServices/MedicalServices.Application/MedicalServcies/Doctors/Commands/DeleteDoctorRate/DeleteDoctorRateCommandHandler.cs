using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.DeleteDoctorRate;


public class DeleteDoctorRateCommandHandler : IRequestHandler<DeleteDoctorRateCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRateRepository _doctorRateRepository;
    public DeleteDoctorRateCommandHandler(
        IDoctorRateRepository doctorRateRepository)
    {
        _doctorRateRepository = doctorRateRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteDoctorRateCommand command, CancellationToken cancellationToken)
    {
        var doctorRate = await _doctorRateRepository.GetByIdAsync(new {command.DoctorId, command.UserId});
        if (doctorRate is null)
            return Errors.Doctor.Rate.NotFound;
        
        _doctorRateRepository.Remove(doctorRate);
        if (await _doctorRateRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.Rate.DeleteFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor rate deleted successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );

    }
}