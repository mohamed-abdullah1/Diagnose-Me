using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctor;


public class GetDoctorQueryValidator : AbstractValidator<GetDoctorQuery>
{
    public GetDoctorQueryValidator()
    {
        RuleFor(v => v.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required");
    }
}