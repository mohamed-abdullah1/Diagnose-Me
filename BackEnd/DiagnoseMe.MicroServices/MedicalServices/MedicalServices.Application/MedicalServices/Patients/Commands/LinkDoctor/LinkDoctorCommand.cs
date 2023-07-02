using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.LinkDoctor;


public record LinkDoctorCommand(
    string Id,
    string DoctorId) : IRequest<ErrorOr<CommandResponse>>;