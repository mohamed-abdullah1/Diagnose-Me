using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctorRate;

public record UpdateDoctorRateCommand(
    string DoctorId,
    string UserId,
    int Rate,
    string? Comment): IRequest<ErrorOr<CommandResponse>>;