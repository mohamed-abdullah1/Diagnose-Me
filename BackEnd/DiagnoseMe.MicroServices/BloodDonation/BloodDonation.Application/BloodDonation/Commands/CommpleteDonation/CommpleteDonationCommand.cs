using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.CommpleteDonation;

public record CommpleteDonationCommand(
    string Id,
    string UserId
) : IRequest<ErrorOr<CommandResponse>>;