using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Comments.Common;

namespace MedicalBlog.Application.MedicalBlog.Comments.Queries.GetCommentsyParentId;

public record GetCommentsByParentIdQuery(
    string ParentId,
    int PageNumber) : IRequest<ErrorOr<List<CommentResponse>>>;