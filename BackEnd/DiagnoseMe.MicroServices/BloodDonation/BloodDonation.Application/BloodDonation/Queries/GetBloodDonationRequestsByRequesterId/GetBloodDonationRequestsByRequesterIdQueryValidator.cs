using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetBloodDonationRequestsByRequesterId;


public class GetBloodDonationRequestsByRequesterIdQueryValidator : AbstractValidator<GetBloodDonationRequestsByRequesterIdQuery>
{
    public GetBloodDonationRequestsByRequesterIdQueryValidator()
    {
        RuleFor(x => x.RequesterId)
            .NotEmpty()
            .WithMessage("Requester id is required.");
    }
}