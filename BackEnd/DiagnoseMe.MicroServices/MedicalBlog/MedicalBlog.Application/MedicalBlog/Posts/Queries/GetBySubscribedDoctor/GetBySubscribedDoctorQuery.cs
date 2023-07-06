using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetBySubscribedDoctor;

public record GetBySubscribedDoctorQuery(
    string UserId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;