using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByDoctorId;

public class GetChecksByDoctorIdQueryValidator : AbstractValidator<GetChecksByDoctorIdQuery>
{
    public GetChecksByDoctorIdQueryValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required.");
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");
    }
}