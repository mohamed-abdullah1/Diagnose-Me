using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByStatus;

public class GetByStatusHandler : IRequestHandler<GetByStatusQuery, ErrorOr<List<DonationResponse>>>
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

    public async Task<ErrorOr<List<DonationResponse>>> Handle(GetByStatusQuery query, CancellationToken cancellationToken)
    {
        var donationRequests = (await _donationRequestRepository
            .GetByStatus(query.Status))
            .OrderByDescending(c => c.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();
        var donationResponses = new List<DonationResponse>();
        foreach (var donationRequest in donationRequests)
        {
            donationResponses.Add(_mapper
                .Map<DonationResponse>(donationRequest));
        }
        return donationResponses;
    }
}