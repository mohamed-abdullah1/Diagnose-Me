using System.Text.RegularExpressions;
using FluentValidation;
using MedicalServices.Domain.Common.Regexes;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinic;

public class AddClinicCommandValidator : AbstractValidator<AddClinicCommand>
{
    public AddClinicCommandValidator()
    {
        RuleFor(x => x.Specialization).
        NotEmpty().
        WithMessage("Specialization is required.").
        MaximumLength(50).
        WithMessage("Specialization must not exceed 50 characters.");
        RuleFor(x => x.Description).
        NotEmpty().
        WithMessage("Description is required.").
        MaximumLength(500).
        WithMessage("Description must not exceed 500 characters.");
        RuleFor(x => x.Base64Picture).
        NotNull().
        WithMessage("Base64Picture is required").
        Must((x => Regex.IsMatch(x, Regexes.Base64Regex))).
        WithMessage("Base64Picture is not valid");    
    }
}