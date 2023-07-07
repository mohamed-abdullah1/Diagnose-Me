using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Questions.Commands.Agreement;
 public class AgreementCommandHandler : IRequestHandler<QuestionAgreementCommand, ErrorOr<CommandResponse>>
 {
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IQuestionAgreementRepository _questionAgreementRepository;

    public AgreementCommandHandler(
        IQuestionRepository questionRepository,
        IUserRepository userRepository,
        IQuestionAgreementRepository questionAgreementRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
        _questionAgreementRepository = questionAgreementRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(QuestionAgreementCommand command, CancellationToken cancellationToken)
    {
        var user = await  _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;
        
        var question = await _questionRepository.GetByIdAsync(command.QuestionId);
        if (question == null)
            return Errors.Question.NotFound;
        
        var questionAgreement = (await _questionAgreementRepository.Get(
            predicate: qa => qa.QuestionId == command.QuestionId && qa.UserId == command.UserId)).
            FirstOrDefault();
        
        if (questionAgreement != null)
        {
            if (questionAgreement.IsAgreed != command.IsAgreed)
            {
                questionAgreement.IsAgreed = command.IsAgreed;
                question.AgreementCount += command.IsAgreed ? 1 : -1;
            }
        }
        else
        {
            questionAgreement = new QuestionAgreement
            {
                Id = Guid.NewGuid().ToString(),
                QuestionId = command.QuestionId,
                UserId = command.UserId,
                IsAgreed = command.IsAgreed,
                Question = question,
                User = user
            };
            question.AgreementCount += command.IsAgreed ? 1 : 0;
            await _questionAgreementRepository.AddAsync(questionAgreement);
        }
        question.AgreeingUsers.Add(user);
        if (await _questionAgreementRepository.SaveAsync() == 0)
            return Errors.Question.AgreementFailed;

        return new CommandResponse(
            true,
            $"Question agreement updated successfully to {command.IsAgreed}",
            $"questions/{question.Id}");
        
    }
 }