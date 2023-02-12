using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BloodDonation.Domain.Common.Errors;
using MapsterMapper;

namespace BloodDonation.Application.BloodDonation.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<DonationResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IMapper _mapper;

    public GetByIdQueryHandler(
        IDonationRequestRepository donationRequestRepository,
        IMapper mapper)
    {
        _donationRequestRepository = donationRequestRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<DonationResponse>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var donationRequest = await _donationRequestRepository.GetByIdAsync(query.Id);
        if (donationRequest == null)
        {
            return Errors.DonationRequest.NotFound;
        }
        return _mapper.Map<DonationResponse>(donationRequest);
    }
}