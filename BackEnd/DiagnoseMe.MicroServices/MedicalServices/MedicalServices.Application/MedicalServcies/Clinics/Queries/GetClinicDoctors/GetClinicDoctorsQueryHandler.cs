using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.MedicalServcies.Clinics.Common;
using MedicalServices.Application.Common.Interfaces.Persistence;

namespace MedicalServices.Application.MedicalServcies.Clinics.Queries.GetClinicDoctors;


public class GetClinicDoctorsQueryHandler : IRequestHandler<GetClinicDoctorsQuery, ErrorOr<List<DoctorResponse>>>
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

    public async Task<ErrorOr<List<DoctorResponse>>> Handle(GetClinicDoctorsQuery query, CancellationToken cancellationToken)
    {
        var doctors = (await _doctorRepository.Get(
            predicate: d => d.ClinicId == query.ClinicId,
            orderBy: d => d.OrderBy(d => d.User.Name),
            include: "User")).
            AsParallel().
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        var doctorsResponse = _mapper.Map<List<DoctorResponse>>(doctors);
        return doctorsResponse;
    }
}