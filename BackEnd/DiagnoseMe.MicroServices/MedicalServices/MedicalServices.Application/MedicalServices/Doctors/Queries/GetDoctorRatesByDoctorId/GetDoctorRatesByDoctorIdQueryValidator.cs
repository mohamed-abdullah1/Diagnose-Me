using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorRatesByDoctorId;

public class GetDoctorRatesByDoctorIdQueryValidator : AbstractValidator<GetDoctorRatesByDoctorIdQuery>
{
    public GetDoctorRatesByDoctorIdQueryValidator()
    {
        RuleFor(q => q.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required.");
        RuleFor(q => q.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");
    }
}