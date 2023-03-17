using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctor;

public class AddDoctorCommandValidator : AbstractValidator<AddDoctorCommand>
{
    public AddDoctorCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .MaximumLength(450).WithMessage("UserId must not exceed 450 characters.");
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(450).WithMessage("Title must not exceed 450 characters.");
        RuleFor(v => v.Bio)
            .NotEmpty().WithMessage("Bio is required.")
            .MaximumLength(450).WithMessage("Bio must not exceed 450 characters.");
        RuleFor(v => v.License)
            .NotEmpty().WithMessage("License is required.")
            .MaximumLength(450).WithMessage("License must not exceed 450 characters.");
        RuleFor(v => v.ClinicId)
            .NotEmpty().WithMessage("ClinicId is required.")
            .MaximumLength(450).WithMessage("ClinicId must not exceed 450 characters.");
    }
}