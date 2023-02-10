using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByBloodType;

public class GetBloodDonationRequestsByBloodTypeQueryHandler : IRequestHandler<GetBloodDonationRequestsByBloodTypeQuery, ErrorOr<List<DonationResponse>>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IMapper _mapper;
    public GetBloodDonationRequestsByBloodTypeQueryHandler(
        IDonationRequestRepository donationRequestRepository,
        IMapper mapper)
    {
        _donationRequestRepository = donationRequestRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<List<DonationResponse>>> Handle(GetBloodDonationRequestsByBloodTypeQuery query, CancellationToken cancellationToken)
    {
        var donationRequests = await _donationRequestRepository.GetByBloodType(query.BloodType);
        var donationResponses = new List<DonationResponse>();
        foreach (var donationRequest in donationRequests)
        {
            donationResponses.Add(_mapper
            .Map<DonationResponse>(donationRequest));
        }
        return donationResponses;
    }
}