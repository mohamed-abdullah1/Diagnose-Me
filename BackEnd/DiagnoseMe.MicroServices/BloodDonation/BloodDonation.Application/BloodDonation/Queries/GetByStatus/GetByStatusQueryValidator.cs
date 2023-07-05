using BloodDonation.Domain.Common.DonationRequestStatus;
using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetByStatus;

public class GetByStatusQueryValidator : AbstractValidator<GetByStatusQuery>
{
    public GetByStatusQueryValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status is required.")
            .Must(x => DonationRequestStatus.All.Contains(x))
            .WithMessage("Status is invalid.");
        RuleFor(x => x.PageNumber)
            .NotEmpty()
            .WithMessage("Page number is required.")
            .GreaterThan(0)
            .WithMessage("Page number must be positive.");
    }
}