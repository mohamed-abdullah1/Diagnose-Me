using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinic;

public class UpdateClinicCommandValidator : AbstractValidator<UpdateClinicCommand>
{
    public UpdateClinicCommandValidator()
    {
        RuleFor(x => x.ClinicId)
            .NotEmpty()
            .WithMessage("ClinicId is required");
        RuleFor(x => x.Description)
            .NotNull()
            .WithMessage("Description is required");
    }
}