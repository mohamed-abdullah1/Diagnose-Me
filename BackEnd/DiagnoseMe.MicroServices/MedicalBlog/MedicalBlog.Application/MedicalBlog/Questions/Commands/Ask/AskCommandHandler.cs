using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Questions.Commands.Ask;

public class AskCommandHandler : IRequestHandler<AskCommand, ErrorOr<CommandResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public AskCommandHandler(
        IQuestionRepository questionRepository,
        IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<CommandResponse>> Handle(AskCommand command, CancellationToken cancellationToken)
    {
        var askingUser = await _userRepository.GetByIdAsync(command.AskingUserId);
        if (askingUser == null)
            return Errors.User.NotFound;
    
        var question = new Question
        {
            Id = Guid.NewGuid().ToString(),
            QuestionString = command.QuestionString,
            AskingUserId = command.AskingUserId,
            CreatedOn = DateTime.UtcNow
        };
        question.AskingUser = askingUser;   
        await _questionRepository.AddAsync(question);

        if (await _questionRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Question.CreationFailed;
                    
        return new CommandResponse(
            true,
            "Question created successfully",
            $"questions/{question.Id}");
    }
}