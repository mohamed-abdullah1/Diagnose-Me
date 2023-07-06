using ErrorOr;
using MediatR;
using BloodDonation.Application.BloodDonation.Common;

namespace BloodDonation.Application.Authentication.Users.Commands.DeleteUser;

public record DeleteUserCommand(
    string Id
) : IRequest<ErrorOr<CommandResponse>>;