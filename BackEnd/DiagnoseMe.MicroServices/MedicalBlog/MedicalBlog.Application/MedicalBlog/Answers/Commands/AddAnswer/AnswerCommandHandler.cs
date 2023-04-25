using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Answers.Commands.AddAnswer;

public class AnswerCommandHandler : IRequestHandler<AnswerCommand, ErrorOr<CommandResponse>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _answeringDoctorRepository;

    public AnswerCommandHandler(
        IAnswerRepository answerRepository,
        IQuestionRepository questionRepository,
        IUserRepository answeringDoctorRepository)
    {
        _answerRepository = answerRepository;
        _questionRepository = questionRepository;
        _answeringDoctorRepository = answeringDoctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AnswerCommand command, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetByIdAsync(command.QuestionId);
        if (question is null)
            return Errors.Question.NotFound;
        var answeringDoctor = await _answeringDoctorRepository.GetByIdAsync(command.AnsweringDoctorId);
        if (answeringDoctor is null){
            // TODO: Check answeringDoctor in auth service
            return Errors.User.NotFound;
        }
        var answer = new Answer
        {
            Id = Guid.NewGuid().ToString(),
            AnswerString = command.AnswerString,
            AnsweringDoctorId = command.AnsweringDoctorId,
            QuestionId = command.QuestionId
        };
        answer.AnsweringDoctor = answeringDoctor;
        answer.Question = question;

        await _answerRepository.AddAsync(answer);
        if (await _answerRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Answer.AddFailed;
        
        return new CommandResponse(
            true,
            $"Answer with id: {answer.Id} was added.",
            $"questions/{question.Id}"
        );
    }
}