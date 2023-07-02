using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecksByPatientId;

public record GetChecksByPatientIdQuery(
    string PatientId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;