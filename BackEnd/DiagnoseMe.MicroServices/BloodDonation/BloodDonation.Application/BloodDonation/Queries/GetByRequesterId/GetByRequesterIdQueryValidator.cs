using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetByRequesterId;


public class GetByRequesterIdQueryValidator : AbstractValidator<GetByRequesterIdQuery>
{
    public GetByRequesterIdQueryValidator()
    {
        RuleFor(x => x.RequesterId)
            .NotEmpty()
            .WithMessage("Requester id is required.");
    }
}