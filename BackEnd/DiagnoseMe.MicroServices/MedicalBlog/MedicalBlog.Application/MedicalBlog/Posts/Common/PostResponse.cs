using MedicalBlog.Application.MedicalBlog.Comments.Common;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Common;

public record PostResponse(
    string Id,
    string Title,
    string Content,
    DoctorData Author,
    List<string> Tags,
    List<string> PostImages,
    string CreatedOn,
    string? ModifiedOn,
    int CommentsCount,
    int RatingCount,
    int ViewsCount,
    float AverageRate
);