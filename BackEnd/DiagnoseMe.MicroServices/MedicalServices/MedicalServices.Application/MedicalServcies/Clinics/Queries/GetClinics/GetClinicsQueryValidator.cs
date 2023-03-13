using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Clinics.Queries.GetClinics;


public class GetClinicsQueryValidator : AbstractValidator<GetClinicsQuery>
{
    public GetClinicsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be positive number");

    }
}