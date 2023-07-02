using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Questions.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionById;

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, ErrorOr<QuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionByIdQueryHandler(
        IQuestionRepository questionRepository, 
        IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<QuestionResponse>> Handle(GetQuestionByIdQuery query, CancellationToken cancellationToken)
    {
        var question = (await _questionRepository.Get(
            predicate: q => q.Id == query.QuestionId,
            include: "Answers,AskingUser,Tags,AgreeingUsers"))
            .FirstOrDefault();
        Console.WriteLine($"========================={question!.AskingUser.Id}==========================");
        Console.WriteLine($"========================={question!.AskingUserId}==========================");
        if (question == null)
            return Errors.Question.NotFound;
        
        var questionResponse = _mapper.Map<QuestionResponse>(question);
        return questionResponse;
    }
}