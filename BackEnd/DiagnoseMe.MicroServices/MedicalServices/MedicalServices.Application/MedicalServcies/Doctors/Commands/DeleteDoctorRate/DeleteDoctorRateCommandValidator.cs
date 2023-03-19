using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.DeleteDoctorRate;

public class DeleteDoctorRateCommandValidator : AbstractValidator<DeleteDoctorRateCommand>
{
    public DeleteDoctorRateCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor id is required.");
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id is required.");
    }
}