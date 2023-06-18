using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinics;

public record GetClinicsQuery(
    int PageNumber
) : IRequest<ErrorOr<PageResponse>>;