using FluentValidation;

namespace MedicalServices.Application.Authentication.Users.Commands.AddUser;



public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
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

    }
}