using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.AgreeComment;

public record AgreeCommentCommand(
    string CommentId,
    string UserId,
    bool IsAgreed) : IRequest<ErrorOr<CommandResponse>>;