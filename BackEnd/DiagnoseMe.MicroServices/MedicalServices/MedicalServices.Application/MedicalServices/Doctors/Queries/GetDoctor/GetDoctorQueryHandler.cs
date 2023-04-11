using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctor;


public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, ErrorOr<DoctorResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public GetDoctorQueryHandler(
        IDoctorRepository doctorRepository, 
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<DoctorResponse>> Handle(GetDoctorQuery query, CancellationToken cancellationToken)
    {
        var doctor = (await _doctorRepository.Get(
            predicate: d => d.Id == query.DoctorId,
            include: "User")).
            FirstOrDefault();
        if (doctor == null)
            return Errors.Doctor.NotFound;

        return _mapper.Map<DoctorResponse>(doctor);
    }
}