using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.AddComment;

public record AddCommentCommand(
    string Content,
    string AuthorId,
    string PostId) : IRequest<ErrorOr<CommandResponse>>;