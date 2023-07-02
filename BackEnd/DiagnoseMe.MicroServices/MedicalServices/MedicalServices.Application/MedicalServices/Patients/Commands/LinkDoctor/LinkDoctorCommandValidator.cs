using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.LinkDoctor;

public class LinkDoctorCommandValidator : AbstractValidator<LinkDoctorCommand>
{
    public LinkDoctorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Patient Id is required.");

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor Id is required.");
    }
}