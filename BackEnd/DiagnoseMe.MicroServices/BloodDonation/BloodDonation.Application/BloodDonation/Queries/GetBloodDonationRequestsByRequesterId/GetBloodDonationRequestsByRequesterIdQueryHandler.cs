using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByRequesterId;

public class GetBloodDonationRequestsByRequesterIdHandler : IRequestHandler<GetBloodDonationRequestsByRequesterIdQuery, ErrorOr<List<DonationResponse>>>
{
    private readonly IDonationRequestRepository _bloodDonationRepository;
    private readonly IMapper _mapper;
    public GetBloodDonationRequestsByRequesterIdHandler(
        IDonationRequestRepository bloodDonationRepository,
        IMapper mapper)
    {
        _bloodDonationRepository = bloodDonationRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<List<DonationResponse>>> Handle(GetBloodDonationRequestsByRequesterIdQuery query, CancellationToken cancellationToken)
    {
        var bloodDonations = await _bloodDonationRepository.GetByRequesterId(query.RequesterId);
        var bloodDonationResponses = new List<DonationResponse>();
        foreach (var bloodDonation in bloodDonations)
        {
            bloodDonationResponses.Add(_mapper
            .Map<DonationResponse>(bloodDonation));
        }
        return bloodDonationResponses;
    }
}