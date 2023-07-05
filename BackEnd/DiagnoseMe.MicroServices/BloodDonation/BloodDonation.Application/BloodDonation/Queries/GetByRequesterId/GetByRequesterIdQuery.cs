using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByRequesterId;

public record GetByRequesterIdQuery(
    string RequesterId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;