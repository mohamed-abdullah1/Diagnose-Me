using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetPopularDoctors;


public class GetPopularDoctorsQueryHandler : IRequestHandler<GetPopularDoctorsQuery, ErrorOr<PageResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    public GetPopularDoctorsQueryHandler(
        IDoctorRepository doctorRepository,
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<PageResponse>> Handle(GetPopularDoctorsQuery query, CancellationToken cancellationToken)
    {
        var doctors = (await _doctorRepository.Get(
            include: "User,Patients,OwnedClinicAddresses,Clinic"
        ));

        if (query.Specialization != null)
            doctors = doctors.Where(d => d.Clinic!.Specialization.ToLower() == query.Specialization.ToLower()).ToList();

        var resDoctors = doctors.
            OrderByDescending(d => d.AverageRate).
            Take(10).
            ToList();
        
        var doctorResponses =  _mapper.Map<List<DoctorResponse>>((resDoctors));

        return new PageResponse(
            doctorResponses.Select(p => (object)p).ToList(),
            1,
            false
        );
    }
}