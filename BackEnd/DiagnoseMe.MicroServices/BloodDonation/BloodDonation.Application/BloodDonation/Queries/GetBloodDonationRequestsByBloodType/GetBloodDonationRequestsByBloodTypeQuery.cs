using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByBloodType;

public record GetBloodDonationRequestsByBloodTypeQuery(
    string BloodType) : IRequest<ErrorOr<List<DonationResponse>>>;