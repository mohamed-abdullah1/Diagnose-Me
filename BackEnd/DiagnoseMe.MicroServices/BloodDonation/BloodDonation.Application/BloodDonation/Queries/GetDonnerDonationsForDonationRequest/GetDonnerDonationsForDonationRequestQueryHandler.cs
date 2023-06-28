using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetDonnerDonationsForDonationRequest;

public class GetDonnerDonationsForDonationRequestQueryHandler : IRequestHandler<GetDonnerDonationsForDonationRequestQuery, ErrorOr<PageResponse>>
{
    private readonly IDonnerDonationRequestRepository _donnerDonationRequestRepository;
    private readonly IMapper _mapper;

    public GetDonnerDonationsForDonationRequestQueryHandler(
        IDonnerDonationRequestRepository donnerDonationRequestRepository,
        IMapper mapper)
    {
        _donnerDonationRequestRepository = donnerDonationRequestRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetDonnerDonationsForDonationRequestQuery query, CancellationToken cancellationToken)
    {
        var donnerDonations = (await _donnerDonationRequestRepository
            .Get(predicate: x => x.DonationRequestId == query.DonationRequestId,
            include: "Donner,Requester"))
            .OrderByDescending(c => c.CreatedOn);
        
        var IsNextPage = donnerDonations.Count() > query.PageNumber * 10;

        var resDonnerDonations = donnerDonations
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();
        
        var donnerDonationsResponse = _mapper.Map<List<DonnerDonationRequest>>(resDonnerDonations);

        return new PageResponse(
            Objects: donnerDonationsResponse.Select(x => (object)x).ToList(),
            IsNextPage: IsNextPage,
            CurrentPage: query.PageNumber
        );
    }
}