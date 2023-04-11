using System.Text.RegularExpressions;
using FluentValidation;
using MedicalServices.Domain.Common.Regexes;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicPicture;


public class UpdateClinicPictureCommandValidator : AbstractValidator<UpdateClinicPictureCommand>
{
    public UpdateClinicPictureCommandValidator()
    {
        RuleFor(x => x.ClinicId)
            .NotEmpty()
            .WithMessage("ClinicId is required");
        RuleFor(x => x.Base64Picture).
            NotNull().
            WithMessage("Base64Picture is required").
            Must((x => Regex.IsMatch(x, Regexes.Base64Regex))).
            WithMessage("Base64Picture is not valid");
    }
}