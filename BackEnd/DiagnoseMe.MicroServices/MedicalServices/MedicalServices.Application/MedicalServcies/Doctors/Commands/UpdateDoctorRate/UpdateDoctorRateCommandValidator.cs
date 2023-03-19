using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.UpdateDoctorRate;

public class UpdateDoctorRateCommandValidator : AbstractValidator<UpdateDoctorRateCommand>
{
    public UpdateDoctorRateCommandValidator()
    {
        RuleFor(x => x.DoctorId).
            NotEmpty()
            .WithMessage("DoctorId is required");
        RuleFor(x => x.UserId).
            NotEmpty().
            WithMessage("UserId is required");
        RuleFor(x => x.Rate).
            NotEmpty().
            WithMessage("Rate is required").
            InclusiveBetween(1, 5).
            WithMessage("Rate must be between 1 and 5");
        RuleFor(x => x.Comment).        
            MaximumLength(500).
            WithMessage("Comment must be less than 500 characters");
    }
}