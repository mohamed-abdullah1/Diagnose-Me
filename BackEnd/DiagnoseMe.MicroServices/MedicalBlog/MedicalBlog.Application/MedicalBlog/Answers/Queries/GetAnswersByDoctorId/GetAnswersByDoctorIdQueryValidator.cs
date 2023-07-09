using FluentValidation;

namespace MedicalBlog.Application.MedicalBlog.Answers.Queries.GetAnswersByDoctorId;

public class GetAnswersByDoctorIdQueryValidator : AbstractValidator<GetAnswersByDoctorIdQuery>
{
    public GetAnswersByDoctorIdQueryValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");
    }
}