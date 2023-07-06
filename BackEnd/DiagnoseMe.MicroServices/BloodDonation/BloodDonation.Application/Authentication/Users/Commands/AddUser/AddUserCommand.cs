using ErrorOr;
using MediatR;
using BloodDonation.Application.BloodDonation.Common;

namespace BloodDonation.Application.Authentication.Users.Commands.AddUser;


public record AddUserCommand(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl,
    string BloodType
) : IRequest<ErrorOr<CommandResponse>>;

