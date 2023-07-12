using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Queries.GetChecks;

public record GetChecksQuery(
    int PageNumber
) : IRequest<ErrorOr<PageResponse>>;