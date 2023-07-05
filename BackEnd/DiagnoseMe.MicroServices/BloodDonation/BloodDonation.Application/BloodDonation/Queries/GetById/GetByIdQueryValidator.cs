using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Queries.GetById;

public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage("Id is required");
    }
}