using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetAvailableDonation;


public class GetAvailableDonationQueryValidator : AbstractValidator<GetAvailableDonationQuery>
{
    public GetAvailableDonationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be greater than or equal to 1.");
    }
}