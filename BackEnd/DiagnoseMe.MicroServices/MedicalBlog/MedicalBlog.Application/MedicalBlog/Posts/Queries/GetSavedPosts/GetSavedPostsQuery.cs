using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetSavedPosts;


public record GetSavedPostsQuery(
    int PageNumber,
    string UserId) : IRequest<ErrorOr<PageResponse>>;