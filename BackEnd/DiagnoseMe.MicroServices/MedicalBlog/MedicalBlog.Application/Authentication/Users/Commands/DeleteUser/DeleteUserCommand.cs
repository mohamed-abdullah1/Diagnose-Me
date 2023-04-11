using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.Authentication.Users.Commands.DeleteUser;

public record DeleteUserCommand(
    string Id
) : IRequest<ErrorOr<CommandResponse>>;