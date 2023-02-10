using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByBloodType;

public class GetByBloodTypeQueryHandler : IRequestHandler<GetByBloodTypeQuery, ErrorOr<List<DonationResponse>>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IMapper _mapper;
    public GetByBloodTypeQueryHandler(
        IDonationRequestRepository donationRequestRepository,
        IMapper mapper)
    {
        _donationRequestRepository = donationRequestRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<List<DonationResponse>>> Handle(GetByBloodTypeQuery query, CancellationToken cancellationToken)
    {
        var donationRequests = (await _donationRequestRepository
            .GetByBloodType(query.BloodType))
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