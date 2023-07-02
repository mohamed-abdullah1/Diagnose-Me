using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Questions.Commands.Agreement;

public class AgreementCommandValidator : AbstractValidator<QuestionAgreementCommand>
{
    public AgreementCommandValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty()
            .WithMessage("QuestionId is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}