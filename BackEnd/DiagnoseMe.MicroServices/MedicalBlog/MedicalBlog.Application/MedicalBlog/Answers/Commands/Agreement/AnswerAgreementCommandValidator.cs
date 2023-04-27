using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Answers.Commands.Agreement;


public class AnswerAgreementCommandValidator : AbstractValidator<AnswerAgreementCommand>
{
    public AnswerAgreementCommandValidator()
    {
        RuleFor(x => x.AnswerId)
            .NotEmpty()
            .WithMessage("AnswerId is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}