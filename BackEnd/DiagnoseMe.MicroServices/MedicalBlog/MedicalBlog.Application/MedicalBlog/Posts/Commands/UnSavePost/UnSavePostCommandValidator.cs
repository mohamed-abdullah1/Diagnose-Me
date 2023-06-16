using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.UnSavePost;

public class UnSavePostCommandValidator : AbstractValidator<UnSavePostCommand>
{
    public UnSavePostCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id is required.");

        RuleFor(x => x.PostId)
            .NotEmpty()
            .WithMessage("Post id is required.");
    }
}