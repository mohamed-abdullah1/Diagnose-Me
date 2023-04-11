using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicDoctors;

public class GetClinicDoctorsQueryValidator : AbstractValidator<GetClinicDoctorsQuery>
{
    public GetClinicDoctorsQueryValidator()
    {
        RuleFor(x => x.ClinicId).
        NotEmpty().
        WithMessage("ClinicId is required");
        RuleFor(x => x.PageNumber).
        NotEmpty().
        WithMessage("PageNumber is required").
        GreaterThanOrEqualTo(1).
        WithMessage("PageNumber must be positive number");
    }
}