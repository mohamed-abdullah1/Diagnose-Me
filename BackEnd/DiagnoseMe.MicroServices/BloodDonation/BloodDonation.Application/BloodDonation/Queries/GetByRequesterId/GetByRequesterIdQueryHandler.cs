using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Queries.GetByRequesterId;

public class GetByRequesterIdHandler : IRequestHandler<GetByRequesterIdQuery, ErrorOr<List<DonationResponse>>>
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
    public async Task<ErrorOr<List<DonationResponse>>> Handle(GetByRequesterIdQuery query, CancellationToken cancellationToken)
    {
        var bloodDonations = (await _bloodDonationRepository
            .GetByRequesterId(query.RequesterId))
            .OrderByDescending(c => c.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();
        var bloodDonationResponses = new List<DonationResponse>();
        foreach (var bloodDonation in bloodDonations)
        {
            bloodDonationResponses.Add(_mapper
            .Map<DonationResponse>(bloodDonation));
        }
        return bloodDonationResponses;
    }
}