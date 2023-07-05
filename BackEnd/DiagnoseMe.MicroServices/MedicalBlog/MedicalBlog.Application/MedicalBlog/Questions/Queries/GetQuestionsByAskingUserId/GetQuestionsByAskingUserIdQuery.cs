using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionsByAskingUserId;

public record GetQuestionsByAskingUserIdQuery(
    int PageNumber,
    string AskingUserId) : IRequest<ErrorOr<PageResponse>>;