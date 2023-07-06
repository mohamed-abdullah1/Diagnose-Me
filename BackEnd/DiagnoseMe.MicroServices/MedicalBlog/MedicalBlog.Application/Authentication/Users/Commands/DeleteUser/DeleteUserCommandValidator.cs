using FluentValidation;

namespace MedicalBlog.Application.Authentication.Users.Commands.DeleteUser;


public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id).
            NotEmpty().
            WithMessage("Id is required.");
    }
}