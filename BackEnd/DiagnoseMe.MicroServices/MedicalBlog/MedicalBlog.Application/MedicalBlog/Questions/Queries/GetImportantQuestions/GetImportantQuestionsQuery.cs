using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetImportantQuestions;

public record GetImportantQuestionsQuery() : IRequest<ErrorOr<PageResponse>>;