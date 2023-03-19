using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.UpdateDoctorRate;

public record UpdateDoctorRateCommand(
    string DoctorId,
    string UserId,
    int Rate,
    string? Comment): IRequest<ErrorOr<CommandResponse>>;