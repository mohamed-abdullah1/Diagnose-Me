using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicDoctors;


public class GetClinicDoctorsQueryHandler : IRequestHandler<GetClinicDoctorsQuery, ErrorOr<PageResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public GetClinicDoctorsQueryHandler(
        IDoctorRepository doctorRepository,
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetClinicDoctorsQuery query, CancellationToken cancellationToken)
    {
        var doctors = (await _doctorRepository.Get(
            predicate: d => d.ClinicId == query.ClinicId,
            orderBy: d => d.OrderBy(d => d.User!.Name),
            include: "User")).
            ToList();
            var IsNextPage = doctors.Count > query.PageNumber * 10;
            var resDoctors = doctors.
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        var doctorsResponse = _mapper.Map<List<DoctorResponse>>(resDoctors);
        return new PageResponse(
            doctorsResponse.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}