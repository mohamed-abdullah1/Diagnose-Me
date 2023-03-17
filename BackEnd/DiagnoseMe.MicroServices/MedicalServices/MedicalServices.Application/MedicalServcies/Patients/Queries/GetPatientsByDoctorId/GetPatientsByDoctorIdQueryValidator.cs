using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Patients.Queries.GetPatientsByDoctorId;

public class GetPatientsByDoctorIdQueryValidator : AbstractValidator<GetPatientsByDoctorIdQuery>
{
    public GetPatientsByDoctorIdQueryValidator()
    {
        RuleFor(v => v.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required");
        RuleFor(v => v.PageNumber)
            .NotEmpty()
            .WithMessage("PageNumber is required")
            .GreaterThan(0)
            .WithMessage("PageNumber must be positive");
    }
}