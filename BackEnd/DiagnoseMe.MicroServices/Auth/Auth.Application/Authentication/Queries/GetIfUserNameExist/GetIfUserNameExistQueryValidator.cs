using FluentValidation;

namespace Auth.Application.Authentication.Queries.GetIfUsernameExist;

public class GetIfUsernameExistQueryValidator : AbstractValidator<GetIfUsernameExistQuery>
{
    public GetIfUsernameExistQueryValidator()
    {
        RuleFor(x => x.Username).
            NotEmpty().
            WithMessage("Username Field is requeried");
    }
}