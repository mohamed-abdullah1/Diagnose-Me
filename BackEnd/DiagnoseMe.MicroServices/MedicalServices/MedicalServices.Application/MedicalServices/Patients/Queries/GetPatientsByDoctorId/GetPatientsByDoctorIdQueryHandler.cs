using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Patients.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Queries.GetPatientsByDoctorId;


public class GetPatientsByDoctorIdQueryHandler : IRequestHandler<GetPatientsByDoctorIdQuery, ErrorOr<PageResponse>>
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

    public async Task<ErrorOr<PageResponse>> Handle(GetPatientsByDoctorIdQuery query, CancellationToken cancellationToken)
    {
        var patients = (await _patientRepository.Get(
            predicate: p => p.Doctors.Any(d => d.Id == query.DoctorId),
            include: "User")).
            ToList();
        var IsNextPage = patients.Count > query.PageNumber * 10;
        var resPatients = patients.
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        
        var patientResponses = _mapper.Map<List<PatientResponse>>(resPatients);

        return new PageResponse(
            patientResponses.Select(p => (object)p).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}