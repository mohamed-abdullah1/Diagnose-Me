using FluentValidation;

namespace Auth.Application.Authentication.Commands.VerifyDoctorIdentity;

public class VerifyDoctorIdentityCommandValidator : AbstractValidator<VerifyDoctorIdentityCommand>
{
    public VerifyDoctorIdentityCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("Username is required");

        RuleFor(x => x.Base64License)
            .NotEmpty()
            .WithMessage("Base64 license is required");
    }
}