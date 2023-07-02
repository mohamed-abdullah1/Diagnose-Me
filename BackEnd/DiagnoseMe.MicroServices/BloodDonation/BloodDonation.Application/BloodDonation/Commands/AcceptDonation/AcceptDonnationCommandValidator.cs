using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Commands.AcceptDonation;

public class AcceptDonationCommandValidator : AbstractValidator<AcceptDonationCommand>
{
    public AcceptDonationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");
    }
}