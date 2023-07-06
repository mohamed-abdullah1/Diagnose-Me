using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.DeleteCheck;

public class DeleteCheckCommandValidator : AbstractValidator<DeleteCheckCommand>
{
    public DeleteCheckCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");
        RuleFor(x => x.CheckId)
            .NotEmpty()
            .WithMessage("CheckId is required.");
    }
}