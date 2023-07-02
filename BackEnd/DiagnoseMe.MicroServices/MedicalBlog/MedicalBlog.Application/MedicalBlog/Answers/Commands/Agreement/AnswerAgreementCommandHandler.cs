using System.Diagnostics;
using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Answers.Commands.Agreement;


public class AnswerAgreementCommandHandler : IRequestHandler<AnswerAgreementCommand, ErrorOr<CommandResponse>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IAnswerAgreementRepository _answerAgreementRepository;
    private readonly IUserRepository _userRepository;

    public AnswerAgreementCommandHandler(
        IAnswerRepository answerRepository,
        IAnswerAgreementRepository answerAgreementRepository,
        IUserRepository userRepository)
    {
        _answerRepository = answerRepository;
        _answerAgreementRepository = answerAgreementRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AnswerAgreementCommand request, CancellationToken cancellationToken)
    {
        var answer = await _answerRepository.GetByIdAsync(request.AnswerId);

        if (answer == null)
            return Errors.Answer.NotFound;

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            return Errors.User.NotFound;
        
        var answerAgreement = (await _answerAgreementRepository.Get(
            predicate: aa => aa.AnswerId == request.AnswerId && aa.UserId == request.UserId)).
            FirstOrDefault();
        
        if (answerAgreement != null)
        {
            if (answerAgreement.IsAgreed == request.IsAgreed)
                return Errors.Answer.AlreadyAgreed;
            
            answerAgreement.IsAgreed = request.IsAgreed;
            answer.AgreementCount += request.IsAgreed ? 1 : -1;
        }
        else
        {
            answerAgreement = new AnswerAgreement
            {
                Id = Guid.NewGuid().ToString(),
                AnswerId = request.AnswerId,
                UserId = request.UserId,
                IsAgreed = request.IsAgreed,
                Answer = answer,
                User = user
            };
            answer.AgreementCount += request.IsAgreed ? 1 : 0;
            await _answerAgreementRepository.AddAsync(answerAgreement);
        }
        answer.AgreeingUsers.Add(user);
        
        if (await _answerAgreementRepository.SaveAsync() == 0)
            return Errors.Answer.AgreementFailed;

        return new CommandResponse(
            Success: true,
            Message: "Agreement was successfully added.",
            Path: $"answers/{answer.Id}"
        );
    }
}