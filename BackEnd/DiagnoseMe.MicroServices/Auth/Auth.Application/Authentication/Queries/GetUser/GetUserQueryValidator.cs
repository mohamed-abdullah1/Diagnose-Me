using FluentValidation;

namespace Auth.Application.Authentication.Queries.GetUser;


public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required");
    }
}