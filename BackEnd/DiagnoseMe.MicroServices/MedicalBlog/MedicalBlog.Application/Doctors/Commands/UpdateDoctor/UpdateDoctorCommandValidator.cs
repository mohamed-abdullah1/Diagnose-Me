using FluentValidation;

namespace MedicalBlog.Application.Doctors.Commands.UpdateDoctor;


public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
            
        RuleFor(x => x.Specialization)
            .NotEmpty()
            .WithMessage("Speciality is required");

        RuleFor(x => x.Rating)
            .NotEmpty()
            .WithMessage("Rating is required");
    }
}