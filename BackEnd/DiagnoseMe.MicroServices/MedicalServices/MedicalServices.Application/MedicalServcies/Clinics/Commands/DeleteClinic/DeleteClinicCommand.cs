using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.DeleteClinic;

public record DeleteClinicCommand(
    string ClinicId
) : IRequest<ErrorOr<CommandResponse>>;
