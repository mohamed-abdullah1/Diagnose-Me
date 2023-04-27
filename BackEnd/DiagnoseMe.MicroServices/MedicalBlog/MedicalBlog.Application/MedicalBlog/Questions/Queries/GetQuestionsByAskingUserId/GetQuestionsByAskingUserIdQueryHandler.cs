using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Questions.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionsByAskingUserId;


public class GetQuestionsByAskingUserIdQueryHandler :  IRequestHandler<GetQuestionsByAskingUserIdQuery, ErrorOr<List<QuestionResponse>>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetQuestionsByAskingUserIdQueryHandler(
        IQuestionRepository questionRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<QuestionResponse>>> Handle(GetQuestionsByAskingUserIdQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.AskingUserId);
        if (user == null)
            return Errors.User.NotFound;

        var questions = (await _questionRepository.Get(
            predicate: q => q.AskingUserId == query.AskingUserId,
            include: "Answers,AskingUser,Tags,AgreeingUsers"))
            .OrderByDescending(x => x.CreatedOn)
            .Skip((query.PageNumber - 1) * 10)
            .ToList();

        var questionsResponse = _mapper.Map<List<QuestionResponse>>(questions);
        return questionsResponse;
    }
}