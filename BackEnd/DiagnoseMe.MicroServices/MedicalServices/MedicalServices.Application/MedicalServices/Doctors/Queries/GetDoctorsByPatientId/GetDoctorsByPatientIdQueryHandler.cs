using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorsByPatientId;


public class GetDoctorsByPatientIdQueryHandler : IRequestHandler<GetDoctorsByPatientIdQuery, ErrorOr<List<DoctorResponse>>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public GetDoctorsByPatientIdQueryHandler(
        IDoctorRepository doctorRepository,
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<DoctorResponse>>> Handle(GetDoctorsByPatientIdQuery query, CancellationToken cancellationToken)
    {
        
        var doctors = (await _doctorRepository.Get(
            predicate: d => d.Patients.Any(p => p.Id == query.PatientId),
            include: "User,Patients,OwnedClinicAddresses,Clinic")).
            AsParallel().
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        var doctorResponses = _mapper.Map<List<DoctorResponse>>(doctors);
        return doctorResponses;
    }
}