using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinic;


public record UpdateClinicCommand(
    string ClinicId,
    string Description): IRequest<ErrorOr<CommandResponse>>;