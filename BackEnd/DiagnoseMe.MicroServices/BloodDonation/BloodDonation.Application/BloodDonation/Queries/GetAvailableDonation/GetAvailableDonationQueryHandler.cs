using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Domain.Common.DonationRequestStatus;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetAvailableDonation;

public class GetAvailableDonationQueryHandler : IRequestHandler<GetAvailableDonationQuery, ErrorOr<PageResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IMapper _mapper;

    public GetAvailableDonationQueryHandler(
        IDonationRequestRepository donationRequestRepository,
        IMapper mapper)
    {
        _donationRequestRepository = donationRequestRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetAvailableDonationQuery query, CancellationToken cancellationToken)
    {
        var donationRequests = (await _donationRequestRepository.Get(
            x => x.Status == DonationRequestStatus.Pending,
             include: "Requester"))
            .OrderBy(c => c.CreatedOn);
        var IsNextPage = donationRequests.Count() > query.PageNumber * 10;

        var resDonationRequest = donationRequests
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();
        var donationResponses = _mapper.Map<List<DonationResponse>>(resDonationRequest);

        return new PageResponse(
            Objects: donationResponses.Select(x => (object)x).ToList(),
            IsNextPage: IsNextPage,
            CurrentPage: query.PageNumber
        );
            

    }
}