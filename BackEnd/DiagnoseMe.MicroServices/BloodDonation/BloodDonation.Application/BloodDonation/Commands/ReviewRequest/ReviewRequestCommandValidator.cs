using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Commands.ReviewRequest;

public class ReviewRequestCommandValidator : AbstractValidator<ReviewRequestCommand>
{
    public ReviewRequestCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(x => x.IsAccepted)
            .NotEmpty()
            .WithMessage("IsAccepted is required.");
    }
}
