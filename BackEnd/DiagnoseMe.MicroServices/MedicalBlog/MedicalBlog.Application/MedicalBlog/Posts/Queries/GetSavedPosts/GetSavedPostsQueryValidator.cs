using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetSavedPosts;

public class GetSavedPostsQueryValidator : AbstractValidator<GetSavedPostsQuery>
{
    public GetSavedPostsQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage("UserId is required");
        
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0");

    }
}