using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByBloodType;

public class GetBloodDonationRequestsByBloodTypeQueryValidator : AbstractValidator<GetBloodDonationRequestsByBloodTypeQuery>
{
    public GetBloodDonationRequestsByBloodTypeQueryValidator()
    {
        RuleFor(x => x.BloodType)
            .NotEmpty()
            .WithMessage("Blood type is required.");
    }
}