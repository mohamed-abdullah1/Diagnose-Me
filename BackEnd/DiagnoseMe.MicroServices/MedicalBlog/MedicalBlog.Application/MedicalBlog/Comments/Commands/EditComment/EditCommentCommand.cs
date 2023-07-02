using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.EditComment;

public record EditCommentCommand(
    string CommentId,
    string UserId,
    string Content) : IRequest<ErrorOr<CommandResponse>>;