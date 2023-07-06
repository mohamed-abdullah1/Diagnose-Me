using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.AddPatient;

public record AddPatientCommand(
    string Id,
    float Height,
    float Weight) : IRequest<ErrorOr<CommandResponse>>;