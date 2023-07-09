using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Queries.GetAnswersByDoctorId;

public record GetAnswersByDoctorIdQuery(
    string DoctorId,
    int PageNumber
) : IRequest<ErrorOr<PageResponse>>;
