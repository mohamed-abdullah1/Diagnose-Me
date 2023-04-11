using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.UnlinkDoctor;


public record UnlinkDoctorCommand(
    string Id,
    string DoctorId) : IRequest<ErrorOr<CommandResponse>>;