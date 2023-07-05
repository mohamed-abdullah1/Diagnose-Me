using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetDonnerDonations;

public record GetDonnerDonationsQuery(
    int PageNumber,
    string DonnerId
) : IRequest<ErrorOr<PageResponse>>;