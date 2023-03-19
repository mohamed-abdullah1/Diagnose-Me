using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.UpdateDoctor;

public record UpdateDoctorCommand(
    string DoctorId,
    string Title,
    string Bio): IRequest<ErrorOr<CommandResponse>>;