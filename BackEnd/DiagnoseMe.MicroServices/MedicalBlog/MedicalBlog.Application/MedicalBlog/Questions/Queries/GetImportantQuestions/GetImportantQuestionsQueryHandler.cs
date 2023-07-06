using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetImportantQuestions;

public class GetImportantQuestionsQueryHandler : IRequestHandler<GetImportantQuestionsQuery, ErrorOr<PageResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetImportantQuestionsQueryHandler(
        IQuestionRepository questionRepository,
        IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PageResponse>> Handle(GetImportantQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.Get(
            include: "Answers,AskingUser,Tags,AgreeingUsers"
        );

        var importantQuestions = questions
            .OrderByDescending(q => q.AgreeingUsers.Count + q.Answers.Count)
            .Take(10)
            .ToList();
            
        var questionsResponse = _mapper.Map<List<QuestionResponse>>(importantQuestions);
        return new PageResponse(
            Objects: questionsResponse.Select(q => (object)q).ToList(),
            CurrentPage: 1,
            IsNextPage: false
        );
    }
}