using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.UpdatePatient;

public record UpdatePatientCommand(
    string Id,
    float Height,
    float Weight) : IRequest<ErrorOr<CommandResponse>>;