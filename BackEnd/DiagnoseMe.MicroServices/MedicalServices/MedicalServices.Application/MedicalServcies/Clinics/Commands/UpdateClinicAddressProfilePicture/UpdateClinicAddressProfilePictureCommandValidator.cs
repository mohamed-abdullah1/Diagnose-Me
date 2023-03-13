using System.Data;
using System.Text.RegularExpressions;
using FluentValidation;
using MedicalServices.Domain.Common.Regexes;

namespace  MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicAddressProfilePicture;

    public   class  UpdateClinicAddressProfilePictureCommandValidator : AbstractValidator<UpdateClinicAddressProfilePictureCommand>
    {
        public  UpdateClinicAddressProfilePictureCommandValidator()
        {
            RuleFor(x => x.ClinicAddressId)
                .NotEmpty()
                .WithMessage( "ClinicAddressId is required" );
            RuleFor(x => x.Base64Picture).
            NotNull().
            WithMessage("Base64Picture is required").
            Must((x => Regex.IsMatch(x, Regexes.Base64Regex))).
            WithMessage("Base64Picture is not valid");
            RuleFor(x => x.DoctorId)
                .NotEmpty()
                .WithMessage( "DoctorId is required" );
        }
    }