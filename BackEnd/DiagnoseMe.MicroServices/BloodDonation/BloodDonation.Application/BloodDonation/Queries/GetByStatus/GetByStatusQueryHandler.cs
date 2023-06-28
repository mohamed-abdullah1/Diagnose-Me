using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByStatus;

public class GetByStatusHandler : IRequestHandler<GetByStatusQuery, ErrorOr<PageResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IMapper _mapper;
    public GetByStatusHandler(
        IDonationRequestRepository donationRequestRepository,
        IMapper mapper)
    {
        _donationRequestRepository = donationRequestRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetByStatusQuery query, CancellationToken cancellationToken)
    {
        var donationRequests = (await _donationRequestRepository
            .Get(predicate: x => x.Status == query.Status))
            .OrderByDescending(c => c.CreatedOn);
        
        var IsNextPage = donationRequests.Count() > query.PageNumber * 10;
        var resDonationRequests = donationRequests
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();
        
        var donationResponses = _mapper.Map<List<DonationResponse>>(resDonationRequests);
        return new PageResponse(
            Objects: donationResponses.Select(x => (object)x).ToList(),
            IsNextPage: IsNextPage,
            CurrentPage: query.PageNumber
        );
        
    }
}