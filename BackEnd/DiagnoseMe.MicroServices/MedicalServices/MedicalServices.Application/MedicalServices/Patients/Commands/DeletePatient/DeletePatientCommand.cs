using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.DeletePatient;

public record DeletePatientCommand(
    string Id) : IRequest<ErrorOr<CommandResponse>>;