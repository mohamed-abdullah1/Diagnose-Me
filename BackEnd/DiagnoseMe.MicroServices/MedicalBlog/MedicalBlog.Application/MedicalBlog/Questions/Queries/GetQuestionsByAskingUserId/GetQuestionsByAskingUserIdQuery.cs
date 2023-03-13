using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Queries.GetQuestionsByAskingUserId;

public record GetQuestionsByAskingUserIdQuery(
    int PageNumber,
    string AskingUserId) : IRequest<ErrorOr<List<QuestionResponse>>>;