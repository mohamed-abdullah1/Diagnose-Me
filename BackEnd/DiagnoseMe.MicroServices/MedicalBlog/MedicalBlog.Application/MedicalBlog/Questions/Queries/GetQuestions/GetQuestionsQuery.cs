using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestions;

public record GetQuestionsQuery(
    int PageNumber) : IRequest<ErrorOr<List<QuestionResponse>>>;
