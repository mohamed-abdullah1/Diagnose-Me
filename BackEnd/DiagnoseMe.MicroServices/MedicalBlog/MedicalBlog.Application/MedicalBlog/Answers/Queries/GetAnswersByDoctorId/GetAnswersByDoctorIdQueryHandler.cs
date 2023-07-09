using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Answers.Common;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Queries.GetAnswersByDoctorId;

public class GetAnswersByDoctorIdQueryHandler : IRequestHandler<GetAnswersByDoctorIdQuery, ErrorOr<PageResponse>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAnswersByDoctorIdQueryHandler(
        IAnswerRepository answerRepository,
        IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetAnswersByDoctorIdQuery query, CancellationToken cancellationToken)
    {
        var answers = (await _answerRepository.Get(
            predicate: a => a.AnsweringDoctorId == query.DoctorId,
            include: "Question,AgreeingUsers"));

        var IsNextPage = answers.Count() > query.PageNumber * 10;

        var resultAnswers = answers
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();

        var answersResponse = _mapper.Map<List<AnswerResponse>>(resultAnswers);
        return new PageResponse(
            answersResponse.Select(a => (object)a).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}