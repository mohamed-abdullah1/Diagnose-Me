using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.DeleteDoctor;

public record DeleteDoctorCommand(
    string DoctorId): IRequest<ErrorOr<CommandResponse>>;