using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Clinics.Common;
using MedicalServices.Application.Common.Interfaces.Persistence;

namespace MedicalServices.Application.Clinics.Queries.GetClinics;

public class GetClinicsQueryHandler : IRequestHandler<GetClinicsQuery, ErrorOr<List<ClinicResponse>>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IMapper _mapper;
    public GetClinicsQueryHandler(
        IClinicRepository clinicRepository,
        IMapper mapper)
    {
        _clinicRepository = clinicRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<List<ClinicResponse>>> Handle(GetClinicsQuery query, CancellationToken cancellationToken)
    {
        var clinics = (await _clinicRepository.Get(
            include: "ClinicAddress,Doctors",
            orderBy: x => x.OrderBy(c => c.Specialization)
        )).
                    AsParallel().
                    Skip((query.PageNumber -1)* 10).
                    Take(10).
                    ToList();
        return _mapper.Map<List<ClinicResponse>>((clinics));
    }
}