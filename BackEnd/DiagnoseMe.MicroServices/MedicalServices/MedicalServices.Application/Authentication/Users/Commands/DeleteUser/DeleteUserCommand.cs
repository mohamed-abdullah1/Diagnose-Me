using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.Authentication.Users.Commands.DeleteUser;

public record DeleteUserCommand(
    string Id
) : IRequest<ErrorOr<CommandResponse>>;