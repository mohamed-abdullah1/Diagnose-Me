using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctor;

public record UpdateDoctorCommand(
    string DoctorId,
    string Title,
    string Bio): IRequest<ErrorOr<CommandResponse>>;