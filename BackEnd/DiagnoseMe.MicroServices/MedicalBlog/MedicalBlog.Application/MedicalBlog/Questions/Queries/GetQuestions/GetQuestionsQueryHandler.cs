using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestions;
public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, ErrorOr<List<QuestionResponse>>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionsQueryHandler(
        IQuestionRepository questionRepository,
        IMapper mapper)
    {
        _questionRepository = questionRepository;

        _mapper = mapper;
    }
 
    public async Task<ErrorOr<List<QuestionResponse>>> Handle(GetQuestionsQuery query, CancellationToken cancellationToken)
    {
        var questions = (await _questionRepository.Get(
            include: "Answers,AskingUser,Tags,AgreeingUsers"))
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .ToList();

        var questionsResponse = _mapper.Map<List<QuestionResponse>>(questions);
        return questionsResponse;
    }
}