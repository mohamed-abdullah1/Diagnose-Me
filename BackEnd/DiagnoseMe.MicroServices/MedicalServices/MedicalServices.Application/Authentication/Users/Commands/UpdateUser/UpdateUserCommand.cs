using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.Authentication.Users.Commands.UpdateUser;


public record UpdateUserCommand(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl,
    bool IsDoctor
) : IRequest<ErrorOr<CommandResponse>>;