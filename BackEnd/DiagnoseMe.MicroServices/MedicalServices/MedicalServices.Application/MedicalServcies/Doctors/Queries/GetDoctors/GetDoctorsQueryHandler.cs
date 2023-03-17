using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctors;


public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, ErrorOr<List<DoctorResponse>>>
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

    public async Task<ErrorOr<List<DoctorResponse>>> Handle(GetDoctorsQuery query, CancellationToken cancellationToken)
    {
        var doctors = (await _doctorRepository.Get(
            orderBy: d => d.OrderBy(d => d.User!.Name),
            include: "User")).
            AsParallel().
            Skip((query.PageNumber - 1) * 10).
            Take(10).
            ToList();
        var doctorsResponse = _mapper.Map<List<DoctorResponse>>(doctors);
        return doctorsResponse;
    }
}