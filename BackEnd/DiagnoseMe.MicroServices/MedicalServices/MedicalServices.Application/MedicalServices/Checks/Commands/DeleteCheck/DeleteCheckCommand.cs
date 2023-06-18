using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.DeleteCheck;

public record DeleteCheckCommand(
    string UserId,
    string CheckId) : IRequest<ErrorOr<CommandResponse>>;