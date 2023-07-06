using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Commands.CancelDonation; 

public class CancelDonationCommandValidator : AbstractValidator<CancelDonationCommand>
{
    public CancelDonationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");
    }
}