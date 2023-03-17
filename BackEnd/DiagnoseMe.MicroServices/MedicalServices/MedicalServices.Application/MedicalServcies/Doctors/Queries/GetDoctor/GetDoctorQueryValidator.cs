using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctor;


public class GetDoctorQueryValidator : AbstractValidator<GetDoctorQuery>
{
    public GetDoctorQueryValidator()
    {
        RuleFor(v => v.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required");
    }
}