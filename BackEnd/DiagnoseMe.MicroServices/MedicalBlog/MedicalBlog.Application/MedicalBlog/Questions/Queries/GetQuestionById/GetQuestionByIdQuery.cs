using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionById;

public record GetQuestionByIdQuery(
    string QuestionId) : IRequest<ErrorOr<QuestionResponse>>;