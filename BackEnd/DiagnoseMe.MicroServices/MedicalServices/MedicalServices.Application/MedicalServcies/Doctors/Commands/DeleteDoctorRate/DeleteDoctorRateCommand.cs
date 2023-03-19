using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.DeleteDoctorRate;


public record DeleteDoctorRateCommand(
    string DoctorId,
    string UserId): IRequest<ErrorOr<CommandResponse>>;