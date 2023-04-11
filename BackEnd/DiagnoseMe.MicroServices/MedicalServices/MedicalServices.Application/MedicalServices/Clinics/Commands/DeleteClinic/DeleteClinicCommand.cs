using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinic;

public record DeleteClinicCommand(
    string ClinicId
) : IRequest<ErrorOr<CommandResponse>>;
