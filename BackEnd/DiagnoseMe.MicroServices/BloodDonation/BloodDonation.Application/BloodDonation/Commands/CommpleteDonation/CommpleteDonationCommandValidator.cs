using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Commands.CommpleteDonation;

public class CommpleteDonationCommandValidator : AbstractValidator<CommpleteDonationCommand>
{
    public CommpleteDonationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}