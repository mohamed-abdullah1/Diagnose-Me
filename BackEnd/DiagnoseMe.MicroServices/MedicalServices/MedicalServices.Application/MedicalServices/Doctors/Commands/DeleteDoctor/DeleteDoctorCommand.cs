using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.DeleteDoctor;

public record DeleteDoctorCommand(
    string DoctorId): IRequest<ErrorOr<CommandResponse>>;