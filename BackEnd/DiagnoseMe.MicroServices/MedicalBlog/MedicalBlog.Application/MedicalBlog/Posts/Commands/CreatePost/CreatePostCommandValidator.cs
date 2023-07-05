using FluentValidation;
using System.Text.RegularExpressions;
using MedicalBlog.Domain.Common.Regexes;


namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .MaximumLength(100)
            .WithMessage("Title must not exceed 100 characters");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required")
            .MaximumLength(3000)
            .WithMessage("Content must not exceed 3000 characters");

        RuleFor(x => x.Tags)
            .NotNull()
            .WithMessage("Tags are required")
            .Must(x => !(string.Join(' ', x).Contains(',')))
            .WithMessage("Tags must not contain commas");
        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .WithMessage("AuthorId is required");

        RuleForEach(x => x.Base64Images).
            Must(x => x is not null && Regex.IsMatch(x, Regexes.Base64Regex)).
                WithMessage(" Data is required and Data must be base64");
    }

   
}