using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.ReviewRequest;

public record ReviewRequestCommand(
    string Id,
    bool IsAccepted,
    string? Reason,
    string UserId
) : IRequest<ErrorOr<CommandResponse>>;