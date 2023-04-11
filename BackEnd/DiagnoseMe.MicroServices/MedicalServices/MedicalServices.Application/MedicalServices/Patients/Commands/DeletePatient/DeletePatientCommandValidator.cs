using FluentValidation;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.DeletePatient;


public class DeletePatientCommandValidator :  AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.");

    }
}