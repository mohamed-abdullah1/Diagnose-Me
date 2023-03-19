using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.DeleteDoctor;


public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
{
    public DeleteDoctorCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor id is required.");
    }
}