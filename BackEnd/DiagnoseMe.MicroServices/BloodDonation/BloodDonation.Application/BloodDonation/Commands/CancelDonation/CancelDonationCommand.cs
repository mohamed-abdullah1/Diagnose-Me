using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.CancelDonation;

public record CancelDonationCommand(
    string Id,
    string UserId
) : IRequest<ErrorOr<CommandResponse>>;