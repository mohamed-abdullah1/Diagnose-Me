using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByBloodType;

public record GetByBloodTypeQuery(
    string BloodType,
    int PageNumber) : IRequest<ErrorOr<List<DonationResponse>>>;