using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Checks.Common;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByPatientId;


public class GetChecksByPatientIdQueryHandler : IRequestHandler<GetChecksByPatientIdQuery, ErrorOr<PageResponse>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IMapper _mapper;

    public GetChecksByPatientIdQueryHandler(
        ICheckRepository checkRepository,
        IMapper mapper)
    {
        _checkRepository = checkRepository;
        _mapper = mapper;

    }

    public async Task<ErrorOr<PageResponse>> Handle(GetChecksByPatientIdQuery query, CancellationToken cancellationToken)
    {
        var checks = await _checkRepository.Get(
            predicate: x => x.PatientId == query.PatientId,
            include: "Patient,Doctor,Allergies,Medications,Diseases,Surgeries,CheckFiles,Doctor.User,Patient.User"
        );

        var IsNextPage = checks.Count() > query.PageNumber * 10;

        var result = checks
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();
        
        var checksResponse = _mapper.Map<List<CheckResponse>>(result);

        return new PageResponse(
            Objects: checksResponse.Select(x => x as object).ToList(),
            IsNextPage: IsNextPage,
            CurrentPage: query.PageNumber
        );
    }
}