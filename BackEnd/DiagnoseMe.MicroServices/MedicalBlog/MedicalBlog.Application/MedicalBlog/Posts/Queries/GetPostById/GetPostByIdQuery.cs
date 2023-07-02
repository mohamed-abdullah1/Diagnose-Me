using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Posts.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostById;

public record GetPostByIdQuery(
    string Id,
    string UserId
) : IRequest<ErrorOr<PostResponse>>;