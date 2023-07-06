using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.Authentication.Users.Commands.AddUser;


public record AddUserCommand(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl,
    bool IsDoctor
) : IRequest<ErrorOr<CommandResponse>>;

