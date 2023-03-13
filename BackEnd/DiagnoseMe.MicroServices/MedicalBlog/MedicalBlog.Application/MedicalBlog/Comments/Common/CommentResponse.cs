using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Common;

public record CommentResponse(
    string Id,
    string ParentId,
    string Content,
    UserData AuthorData,
    string CreatedOn,
    string? ModifiedOn,
    int ComentAgreementsCount,
    List<UserData> CommentAgreementUsers
);