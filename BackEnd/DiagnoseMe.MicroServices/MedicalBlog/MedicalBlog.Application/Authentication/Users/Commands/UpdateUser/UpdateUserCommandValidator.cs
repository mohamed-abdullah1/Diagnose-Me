using FluentValidation;

namespace MedicalBlog.Application.Authentication.Users.Commands.UpdateUser;


public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id).
            NotEmpty().
            WithMessage("Id is required.");
        RuleFor(x => x.Name).
            NotEmpty().
            WithMessage("Name is required.");
        RuleFor(x => x.FullName).
            NotEmpty().
            WithMessage("FullName is required.");
        RuleFor(x => x.ProfilePictureUrl).
            NotEmpty().
            WithMessage("ProfilePictureUrl is required.");
    }
}