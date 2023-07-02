using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinic;

public record AddClinicCommand(
    string Specialization,
    string Description,
    string Base64Picture) : IRequest<ErrorOr<CommandResponse>>;