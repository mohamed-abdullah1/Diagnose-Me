using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByPatientId;

public class GetChecksByPatientIdQueryValidator : AbstractValidator<GetChecksByPatientIdQuery>
{
    public GetChecksByPatientIdQueryValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty()
            .WithMessage("PatientId is required.");
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");
    }
}