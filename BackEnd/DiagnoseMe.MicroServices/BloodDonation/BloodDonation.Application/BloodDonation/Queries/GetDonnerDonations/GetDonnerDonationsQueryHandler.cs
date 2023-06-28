using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetDonnerDonations;

public class GetDonnerDonationsQueryHandler : IRequestHandler<GetDonnerDonationsQuery, ErrorOr<PageResponse>>
{
    private readonly IDonnerDonationRequestRepository _bloodDonationRepository;
    private readonly IMapper _mapper;

    public GetDonnerDonationsQueryHandler(
        IDonnerDonationRequestRepository bloodDonationRepository,
        IMapper mapper)
    {
        _bloodDonationRepository = bloodDonationRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetDonnerDonationsQuery query, CancellationToken cancellationToken)
    {
        var donnerDonations = (await _bloodDonationRepository
            .Get(predicate: x => x.DonnerId == query.DonnerId,
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