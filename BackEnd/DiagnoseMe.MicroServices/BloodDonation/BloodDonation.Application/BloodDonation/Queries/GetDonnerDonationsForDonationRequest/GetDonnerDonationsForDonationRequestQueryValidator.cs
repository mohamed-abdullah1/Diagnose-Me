using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetDonnerDonationsForDonationRequest;

public class GetDonnerDonationsForDonationRequestQueryValidator : AbstractValidator<GetDonnerDonationsForDonationRequestQuery>
{
    public GetDonnerDonationsForDonationRequestQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be greater than or equal to 1.");
    }
}
