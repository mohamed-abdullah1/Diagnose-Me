using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetAvailableDonation;

public record GetAvailableDonationQuery(
    int PageNumber
) : IRequest<ErrorOr<PageResponse>>;