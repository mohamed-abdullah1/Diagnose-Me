namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostsByTags;
using ErrorOr;
using global::MedicalBlog.Application.MedicalBlog.Posts.Common;
using MediatR;

public record GetPostsByTagsQuery(
    int PageNumber,
    List<string> Tags,
    string UserId) : IRequest<ErrorOr<List<PostResponse>>>;
