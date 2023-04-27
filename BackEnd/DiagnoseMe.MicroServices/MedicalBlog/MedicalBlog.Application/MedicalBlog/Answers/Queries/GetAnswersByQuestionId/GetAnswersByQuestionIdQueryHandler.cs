using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Answers.Common;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Queries.GetAnswersByQuestionId;

public class GetAnswersByQuestionIdQueryHandler : IRequestHandler<GetAnswersByQuestionIdQuery, ErrorOr<List<AnswerResponse>>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAnswersByQuestionIdQueryHandler(
        IAnswerRepository answerRepository, 
        IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<AnswerResponse>>> Handle(GetAnswersByQuestionIdQuery query, CancellationToken cancellationToken)
    {
        var answers = (await _answerRepository.Get(
            predicate: a => a.QuestionId == query.QuestionId,
            include: "AnsweringUser,AgreeingUsers"))
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .ToList();

        var answersResponse = _mapper.Map<List<AnswerResponse>>(answers);
        return answersResponse;
    }
}