using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.RatePost;

public class RatePostCommandValidator : AbstractValidator<RatePostCommand>
{
    public RatePostCommandValidator()
    {
        RuleFor(x => x.PostId)
            .NotEmpty()
            .WithMessage("PostId is required");
        RuleFor(x => x.Rating)
            .NotEmpty()
            .WithMessage("Rating is required")
            .InclusiveBetween(1, 5)
            .WithMessage("Rating must be between 1 and 5");
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}