using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdatePricePerSession;


public class UpdatePricePerSessionValidator : AbstractValidator<UpdatePricePerSessionCommand>
{
    public UpdatePricePerSessionValidator()
    {
        RuleFor(x => x.doctorId)
            .NotEmpty()
            .WithMessage("Doctor id is required.");

        RuleFor(x => x.price)
            .NotEmpty()
            .WithMessage("Price per session is required.");
    }
}