using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.AddPatient;

public class AddPatientCommendValidator :  AbstractValidator<AddPatientCommand>
{
    public AddPatientCommendValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.");
        
        RuleFor(v => v.Height).NotEmpty().WithMessage("Height is required.");
        RuleFor(v => v.Weight).NotEmpty().WithMessage("Weight is required.");

    }
}