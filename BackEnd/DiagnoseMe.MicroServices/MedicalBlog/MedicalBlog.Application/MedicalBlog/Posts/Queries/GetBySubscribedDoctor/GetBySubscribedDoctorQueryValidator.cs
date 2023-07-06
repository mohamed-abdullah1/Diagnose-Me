using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetBySubscribedDoctor; 

public class GetBySubscribedDoctorQueryValidator : AbstractValidator<GetBySubscribedDoctorQuery>
{
    public GetBySubscribedDoctorQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id is required.");

        RuleFor(x => x.PageNumber)
            .NotEmpty()
            .WithMessage("Page number is required.");
    }
}