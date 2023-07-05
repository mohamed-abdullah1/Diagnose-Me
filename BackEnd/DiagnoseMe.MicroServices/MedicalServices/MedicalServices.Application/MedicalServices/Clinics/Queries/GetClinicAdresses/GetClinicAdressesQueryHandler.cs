using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicAdresses;

public class GetClinicAddressesQueryHandler : IRequestHandler<GetClinicAddressesQuery, ErrorOr<PageResponse>>
{
    private readonly IClinicAddressRepository _clinicAddressRepository;
    private readonly IMapper _mapper;

    public GetClinicAddressesQueryHandler(
        IClinicAddressRepository clinicAddressRepository,
         IMapper mapper)
    {
        _clinicAddressRepository = clinicAddressRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetClinicAddressesQuery query, CancellationToken cancellationToken)
    {
        var clinicAddresses = (await _clinicAddressRepository.Get(
            predicate: x => x.ClinicId == query.ClinicId,
            include: "Doctor",
            orderBy: x => x.OrderBy(c => c.Id)))
            .ToList();

            var IsNextPage = clinicAddresses.Count > query.PageNumber * 10;
            var resClinicAddresses = clinicAddresses.
                Skip((query.PageNumber - 1) * 10).
                Take(10).
                ToList();
        var clinicAddressesResponse = _mapper.Map<List<ClinicAddressResponse>>(resClinicAddresses);
        return new PageResponse(
            clinicAddressesResponse.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}