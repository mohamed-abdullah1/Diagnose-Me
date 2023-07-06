using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByRequesterId;

public class GetByRequesterIdHandler : IRequestHandler<GetByRequesterIdQuery, ErrorOr<PageResponse>>
{
    private readonly IDonationRequestRepository _bloodDonationRepository;
    private readonly IMapper _mapper;
    public GetByRequesterIdHandler(
        IDonationRequestRepository bloodDonationRepository,
        IMapper mapper)
    {
        _bloodDonationRepository = bloodDonationRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<PageResponse>> Handle(GetByRequesterIdQuery query, CancellationToken cancellationToken)
    {
        var donationRequests = (await _bloodDonationRepository
            .Get(predicate: x => x.RequesterId == query.RequesterId,
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