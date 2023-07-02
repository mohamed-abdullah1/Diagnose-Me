using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPopularPosts;

public record GetPopularPostsQuery(
    string? UserId
) : IRequest<ErrorOr<PageResponse>>;