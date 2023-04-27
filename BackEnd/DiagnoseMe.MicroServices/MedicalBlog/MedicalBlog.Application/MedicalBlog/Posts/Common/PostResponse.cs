using MedicalBlog.Application.MedicalBlog.Comments.Common;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Common;

public record PostResponse(
    string Id,
    string Title,
    string Content,
    UserData Author,
    List<string> Tags,
    string CreatedOn,
    string? ModifiedOn,
    int CommentsCount,
    int RatingCount,
    int ViewsCount,
    float AverageRate
);