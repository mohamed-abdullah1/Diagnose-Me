using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinics;

public class GetClinicsQueryHandler : IRequestHandler<GetClinicsQuery, ErrorOr<PageResponse>>
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
    public async Task<ErrorOr<PageResponse>> Handle(GetClinicsQuery query, CancellationToken cancellationToken)
    {
        var clinics = (await _clinicRepository.Get(
            include: "ClinicAddresses,Doctors",
            orderBy: x => x.OrderBy(c => c.Specialization)
        )).ToList();
        var IsNextPage = clinics.Count > query.PageNumber * 10;
        var resClinics = clinics.
            Skip((query.PageNumber -1)* 10).
            Take(10).
            ToList();
        var clinicResonses =  _mapper.Map<List<ClinicResponse>>((resClinics));
        return new PageResponse(
            clinicResonses.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}