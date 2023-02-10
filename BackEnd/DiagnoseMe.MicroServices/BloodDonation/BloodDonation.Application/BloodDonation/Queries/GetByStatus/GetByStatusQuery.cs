using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByStatus;

public record GetByStatusQuery(
    string Status,
    int PageNumber) : IRequest<ErrorOr<List<DonationResponse>>>;