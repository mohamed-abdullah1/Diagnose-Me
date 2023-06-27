using FluentValidation;

namespace Auth.Application.Authentication.Queries.GetIfEmailExist;

public class GetIfEmailExistQueryValidator : AbstractValidator<GetIfEmailExistQuery>
{
    public GetIfEmailExistQueryValidator()
    {
        RuleFor(x => x.Email).
            NotEmpty().
            WithMessage("Email Field is requeried");
    }
}