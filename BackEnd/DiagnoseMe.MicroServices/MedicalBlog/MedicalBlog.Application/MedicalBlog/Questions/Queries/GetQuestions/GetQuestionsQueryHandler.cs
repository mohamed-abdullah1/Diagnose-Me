using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestions;
public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, ErrorOr<PageResponse>>
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
 
    public async Task<ErrorOr<PageResponse>> Handle(GetQuestionsQuery query, CancellationToken cancellationToken)
    {
        var questions = (await _questionRepository.Get(
            include: "Answers,AskingUser,Tags,AgreeingUsers"));
        
        var IsNextPage = questions.Count() > query.PageNumber * 10;

        var resultQuestions = questions
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .Take(10)
            .ToList();

        var questionsResponse = _mapper.Map<List<QuestionResponse>>(questions);
        return new PageResponse(
            questionsResponse.Select(q => (object)q).ToList(),
            query.PageNumber,
            IsNextPage
        );
    }
}