using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetById;

public record GetByIdQuery(
    string Id) : IRequest<ErrorOr<DonationResponse>>;