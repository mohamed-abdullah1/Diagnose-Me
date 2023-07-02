using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorsByPatientId;

public class GetDoctorsByPatientIdQueryValidator : AbstractValidator<GetDoctorsByPatientIdQuery>
{
    public GetDoctorsByPatientIdQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be positive");
        RuleFor(x => x.PatientId)
            .NotEmpty()
            .WithMessage("Patient id must be provided");
    }
}