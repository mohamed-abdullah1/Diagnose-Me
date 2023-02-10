using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByRequesterId;

public record GetBloodDonationRequestsByRequesterIdQuery(
    string RequesterId) : IRequest<ErrorOr<List<DonationResponse>>>;