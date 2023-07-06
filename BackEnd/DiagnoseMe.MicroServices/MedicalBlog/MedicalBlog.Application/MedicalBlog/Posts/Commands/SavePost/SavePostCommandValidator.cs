using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.SavePost;

public class SavePostCommandValidator : AbstractValidator<SavePostCommand>
{
    public SavePostCommandValidator()
    {
        RuleFor(x => x.PostId)
            .NotEmpty()
            .WithMessage("PostId is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}
