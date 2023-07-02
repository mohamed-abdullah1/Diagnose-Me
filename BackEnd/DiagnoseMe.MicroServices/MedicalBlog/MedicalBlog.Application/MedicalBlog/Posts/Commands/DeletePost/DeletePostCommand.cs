using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.DeletePost;

public record DeletePostCommand(
    string PostId,
    string UserId,
    List<string> Roles) : IRequest<ErrorOr<CommandResponse>>;