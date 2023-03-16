using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctors;


public class GetDoctorsQueryValidator : AbstractValidator<GetDoctorsQuery>
{
    public GetDoctorsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be positive");
    }
}