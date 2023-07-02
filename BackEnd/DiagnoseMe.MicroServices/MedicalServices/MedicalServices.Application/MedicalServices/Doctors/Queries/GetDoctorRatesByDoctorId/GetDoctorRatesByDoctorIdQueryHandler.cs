using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorRatesByDoctorId;

public class GetDoctorRatesByDoctorIdQueryHandler : IRequestHandler<GetDoctorRatesByDoctorIdQuery, ErrorOr<PageResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public GetDoctorRatesByDoctorIdQueryHandler(
        IDoctorRepository doctorRepository,
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetDoctorRatesByDoctorIdQuery query, CancellationToken cancellationToken)
    {
        var doctor = (await _doctorRepository.Get(
            predicate: d => d.Id == query.DoctorId,
            include: "DoctorRates"))
            .FirstOrDefault();
        if (doctor is null)
            return Errors.Doctor.NotFound;

        var doctorRates = doctor.DoctorRates.
            OrderByDescending(r => r.Rate);

        var IsNextPage = doctorRates.Count() > query.PageNumber * 10;
        var resDoctorRates = doctorRates.
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        var doctorRatesResponse = _mapper.Map<List<DoctorRateResponse>>(resDoctorRates);

        return new PageResponse(
            doctorRatesResponse.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}