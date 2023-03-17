using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Patients.Common;

namespace MedicalServices.Application.MedicalServcies.Patients.Queries.GetPatientsByDoctorId;


public class GetPatientsByDoctorIdQueryHandler : IRequestHandler<GetPatientsByDoctorIdQuery, ErrorOr<List<PatientResponse>>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public GetPatientsByDoctorIdQueryHandler(
        IPatientRepository patientRepository,
        IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<PatientResponse>>> Handle(GetPatientsByDoctorIdQuery query, CancellationToken cancellationToken)
    {
        var patients = (await _patientRepository.Get(
            predicate: p => p.Doctors.Any(d => d.Id == query.DoctorId),
            include: "User")).
            AsParallel().
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        
        return _mapper.Map<List<PatientResponse>>(patients);
    }
}