using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.AddClinic;

public record AddClinicCommand(
    string Specialization,
    string Description,
    string Base64Picture) : IRequest<ErrorOr<CommandResponse>>;