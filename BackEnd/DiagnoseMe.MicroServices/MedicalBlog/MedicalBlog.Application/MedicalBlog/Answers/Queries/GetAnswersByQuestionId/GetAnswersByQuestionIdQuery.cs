using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Answers.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Queries.GetAnswersByQuestionId;

public record GetAnswersByQuestionIdQuery(
    string QuestionId,
    int PageNumber) : IRequest<ErrorOr<List<AnswerResponse>>>;