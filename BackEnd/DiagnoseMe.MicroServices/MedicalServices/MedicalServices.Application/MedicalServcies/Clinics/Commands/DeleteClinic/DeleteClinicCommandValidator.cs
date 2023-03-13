using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.DeleteClinic;


public class DeleteClinicCommandValidator : AbstractValidator<DeleteClinicCommand>
{
    public DeleteClinicCommandValidator()
    {
        RuleFor(x => x.ClinicId)
            .NotEmpty()
            .WithMessage("ClinicId is required");
    }
}