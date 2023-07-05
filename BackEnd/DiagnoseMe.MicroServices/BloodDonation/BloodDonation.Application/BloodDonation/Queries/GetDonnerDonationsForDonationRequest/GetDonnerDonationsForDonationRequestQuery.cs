using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetDonnerDonationsForDonationRequest;

public record GetDonnerDonationsForDonationRequestQuery(
    int PageNumber,
    string DonationRequestId
) : IRequest<ErrorOr<PageResponse>>;