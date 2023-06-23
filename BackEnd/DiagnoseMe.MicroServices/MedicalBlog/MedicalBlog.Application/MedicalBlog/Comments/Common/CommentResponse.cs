using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Common;

public record CommentResponse(
    string Id,
    string ParentId,
    string Content,
    DoctorData Auther,
    string CreatedOn,
    string? ModifiedOn,
    int AgreementCount,
    int DisagreementCount,
    int ChildCommentsCount);