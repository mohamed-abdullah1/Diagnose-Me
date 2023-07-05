using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.DeleteDoctorRate;


public record DeleteDoctorRateCommand(
    string DoctorId,
    string UserId): IRequest<ErrorOr<CommandResponse>>;