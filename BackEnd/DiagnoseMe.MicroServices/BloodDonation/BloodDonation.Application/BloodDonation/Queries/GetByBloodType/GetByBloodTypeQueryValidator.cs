using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetByBloodType;

public class GetByBloodTypeQueryValidator : AbstractValidator<GetByBloodTypeQuery>
{
    public GetByBloodTypeQueryValidator()
    {
        RuleFor(x => x.BloodType)
            .NotEmpty()
            .WithMessage("Blood type is required.");
        RuleFor(x => x.PageNumber)
            .NotEmpty()
            .WithMessage("Page number is required.")
            .GreaterThan(0)
            .WithMessage("Page number must be positive.");

    }
}