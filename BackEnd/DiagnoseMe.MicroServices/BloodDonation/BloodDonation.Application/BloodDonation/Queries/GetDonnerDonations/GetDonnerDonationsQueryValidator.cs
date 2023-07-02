using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetDonnerDonations;

public class GetDonnerDonationsQueryValidator : AbstractValidator<GetDonnerDonationsQuery>
{
    public GetDonnerDonationsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be greater than or equal to 1");
        RuleFor(x => x.DonnerId)
            .NotEmpty()
            .WithMessage("Donner id must not be empty.");
    }
}
