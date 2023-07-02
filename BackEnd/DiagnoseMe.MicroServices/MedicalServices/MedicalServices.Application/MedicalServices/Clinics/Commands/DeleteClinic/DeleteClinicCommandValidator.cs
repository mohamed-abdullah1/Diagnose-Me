using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinic;


public class DeleteClinicCommandValidator : AbstractValidator<DeleteClinicCommand>
{
    public DeleteClinicCommandValidator()
    {
        RuleFor(x => x.ClinicId)
            .NotEmpty()
            .WithMessage("ClinicId is required");
    }
}