using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.SavePost;


public record SavePostCommand(
    string PostId,
    string UserId) : IRequest<ErrorOr<CommandResponse>>;