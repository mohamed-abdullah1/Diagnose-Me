using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctor;


public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, ErrorOr<DoctorResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorRateRepository _doctorRateRepository;
    private readonly IMapper _mapper;

    public GetDoctorQueryHandler(
        IDoctorRepository doctorRepository,
        IDoctorRateRepository doctorRateRepository, 
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
        _doctorRateRepository = doctorRateRepository;
    }

    public async Task<ErrorOr<DoctorResponse>> Handle(GetDoctorQuery query, CancellationToken cancellationToken)
    {
        var doctor = (await _doctorRepository.Get(
            predicate: d => d.Id == query.DoctorId,
            include: "User,Patients,ClinicAddresses,Clinic")).
            FirstOrDefault();
        if (doctor == null)
            return Errors.Doctor.NotFound;

        var doctorRates = (await _doctorRateRepository.Get(
            predicate: r => r.DoctorId == query.DoctorId,
            include: "User")).ToList();

        doctor.DoctorRates = doctorRates;  
        return _mapper.Map<DoctorResponse>(doctor);
    }
}