using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.AcceptDonation;

public record AcceptDonationCommand(
    string Id,
    string UserId
) : IRequest<ErrorOr<CommandResponse>>;