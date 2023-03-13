using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinic;


public record UpdateClinicCommand(
    string ClinicId,
    string Description): IRequest<ErrorOr<CommandResponse>>;