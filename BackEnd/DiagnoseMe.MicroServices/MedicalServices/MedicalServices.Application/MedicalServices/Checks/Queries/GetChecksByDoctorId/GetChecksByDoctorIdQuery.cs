using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByDoctorId;

public record GetChecksByDoctorIdQuery(
    string DoctorId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;