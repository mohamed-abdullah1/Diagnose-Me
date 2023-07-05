using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPostsByDocterId;

public record GetPostsByDoctorIdQuery(
    string DoctorId,
    int PageNumber,
    string UserId) : IRequest<ErrorOr<PageResponse>>;