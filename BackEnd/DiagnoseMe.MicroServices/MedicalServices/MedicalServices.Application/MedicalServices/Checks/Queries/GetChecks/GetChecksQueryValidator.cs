using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecks;

public class GetChecksQueryValidator : AbstractValidator<GetChecksQuery>
{
    public GetChecksQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .NotEmpty()
            .WithMessage("Page number is required.")
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");
    }
}