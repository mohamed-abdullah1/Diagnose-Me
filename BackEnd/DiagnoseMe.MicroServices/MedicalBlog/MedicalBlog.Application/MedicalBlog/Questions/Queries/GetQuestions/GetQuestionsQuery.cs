using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestions;

public record GetQuestionsQuery(
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;
