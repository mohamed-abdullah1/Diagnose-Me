using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;
using MedicalServices.Application.Common.Interfaces.Persistence;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicAdresses;

public class GetClinicAddressesQueryHandler : IRequestHandler<GetClinicAddressesQuery, ErrorOr<List<ClinicAddressResponse>>>
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

    public async Task<ErrorOr<List<ClinicAddressResponse>>> Handle(GetClinicAddressesQuery query, CancellationToken cancellationToken)
    {
        var clinicAddresses = (await _clinicAddressRepository.Get(
            predicate: x => x.ClinicId == query.ClinicId,
            include: "Addresses",
            orderBy: x => x.OrderBy(c => c.Id))).
            AsParallel().
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        return _mapper.Map<List<ClinicAddressResponse>>(clinicAddresses);
    }
}