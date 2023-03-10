using ErrorOr;
using MediatR;
using MedicalServices.Application.Clinics.Common;

namespace MedicalServices.Application.Clinics.Queries.GetClinics;

public record GetClinicsQuery(
    int PageNumber
) : IRequest<ErrorOr<List<ClinicResponse>>>;