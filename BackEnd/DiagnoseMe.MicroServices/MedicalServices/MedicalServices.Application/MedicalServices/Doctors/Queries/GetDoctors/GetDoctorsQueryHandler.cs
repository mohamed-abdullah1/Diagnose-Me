using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctors;


public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, ErrorOr<PageResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public GetDoctorsQueryHandler(
        IDoctorRepository doctorRepository,
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetDoctorsQuery query, CancellationToken cancellationToken)
    {
        
        var doctors = (await _doctorRepository.Get(
            orderBy: d => d.OrderBy(d => d.User!.Name),
            include: "User,Patients,OwnedClinicAddresses,Clinic")).
            ToList();
        
        if (!String.IsNullOrEmpty(query.Name))
            doctors = doctors.Where(d => d.User!.Name.ToLower().Contains(query.Name.ToLower())).ToList();
        
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