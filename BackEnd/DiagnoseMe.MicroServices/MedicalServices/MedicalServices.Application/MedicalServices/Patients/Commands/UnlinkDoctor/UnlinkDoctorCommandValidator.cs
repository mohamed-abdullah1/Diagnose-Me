using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.UnlinkDoctor;

public class UnlinkDoctorCommandValidator : AbstractValidator<UnlinkDoctorCommand>
{
    public UnlinkDoctorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Patient Id is required.");

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor Id is required.");
    }
}