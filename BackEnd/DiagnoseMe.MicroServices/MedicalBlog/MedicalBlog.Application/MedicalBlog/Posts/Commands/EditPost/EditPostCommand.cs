using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.EditPost;

public record EditPostCommand(
    string PostId,
    string Title,
    string Content,
    List<string> Tags,
    List<string> RemovedImagesUrls,
    List<string> Base64Images,
    string UserId) : IRequest<ErrorOr<CommandResponse>>;