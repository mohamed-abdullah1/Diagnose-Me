using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.Authentication.Users.Commands.UpdateUser;


public record UpdateUserCommand(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl
) : IRequest<ErrorOr<CommandResponse>>;