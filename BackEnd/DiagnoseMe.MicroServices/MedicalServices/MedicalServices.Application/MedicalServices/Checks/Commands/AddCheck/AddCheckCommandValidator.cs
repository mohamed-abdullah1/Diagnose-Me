using FluentValidation;
using MedicalServices.Domain.Common.FIles;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.AddCheck;

public class AddCheckCommandValidator : AbstractValidator<AddCheckCommand>
{
    public AddCheckCommandValidator()
    {
        RuleFor(x => x.Name).
            NotEmpty().
                WithMessage("Name is required.").
            MaximumLength(50).
                WithMessage("Name must not exceed 50 characters.");
        RuleFor(x => x.Type).
            NotEmpty().
                WithMessage("Type is required.").
            MaximumLength(50).
                WithMessage("Type must not exceed 50 characters.");
        RuleFor(x => x.Data).
            NotEmpty().
                WithMessage("Data is required.").
            MaximumLength(500).
                WithMessage("Data must not exceed 500 characters.");
        RuleFor(x => x.Report).
            NotEmpty().
                WithMessage("Report is required.").
            MaximumLength(500).
                WithMessage("Report must not exceed 500 characters.");
        
        RuleFor(x => x.PatientId).
            NotEmpty().
                WithMessage("PatientId is required.").
        MaximumLength(50).
                WithMessage("PatientId must not exceed 50 characters.");

        RuleForEach(x => x.Base64Files).
            Must(x => x.Type is not null && x.Data is not null).
                WithMessage("Type and Data are required.").
            Must(x => AllowedFileTypes.AllowedTypes.Contains(x.Type)).
                When(x => x.Type is not null).
                WithMessage("Type is not allowed.");
            
    }
}