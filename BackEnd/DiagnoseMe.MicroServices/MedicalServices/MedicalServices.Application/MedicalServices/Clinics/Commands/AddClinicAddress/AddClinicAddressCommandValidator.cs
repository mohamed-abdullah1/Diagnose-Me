using System.Text.RegularExpressions;
using FluentValidation;
using MedicalServices.Domain.Common.Regexes;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinicAddress;

public class AddClinicAddressCommandValidator : AbstractValidator<AddClinicAddressCommand>
{
    public AddClinicAddressCommandValidator()
    {
        RuleFor(x => x.OwnerId).
            NotEmpty().
            WithMessage("ClinicId is required");
        RuleFor(x => x.OwnerId).
            NotEmpty().
            WithMessage("ClinicId is required");
        RuleFor(x => x.Name).
            NotEmpty().
            WithMessage("Name is required");
        RuleFor(x => x.Street).
            NotNull().
            WithMessage("Street is required");
        RuleFor(x => x.City).
            NotNull().
            WithMessage("City is required");
        RuleFor(x => x.State).
            NotNull().
            WithMessage("State is required");
        RuleFor(x => x.Country).
            NotNull().
            WithMessage("Country is required");
        RuleFor(x => x.ZipCode).
            NotNull().
            WithMessage("ZipCode is required");
        RuleFor(x => x.OpenTime).
            NotNull().
            WithMessage("OpenTime is required").
            Must(x => Regex.IsMatch(x, Regexes.Time));
        RuleFor(x => x.CloseTime).
            NotNull().
            WithMessage("CloseTime is required").
            Must(x => Regex.IsMatch(x, Regexes.Time));
        RuleFor(x => x.Base64Picture).
            NotNull().
            WithMessage("Base64Picture is required").
            Must((x => Regex.IsMatch(x, Regexes.Base64Regex))).
            WithMessage("Base64Picture is not valid");
    }
}