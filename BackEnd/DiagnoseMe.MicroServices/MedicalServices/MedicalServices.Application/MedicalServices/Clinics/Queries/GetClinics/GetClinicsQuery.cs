using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinics;

public record GetClinicsQuery(
    int PageNumber
) : IRequest<ErrorOr<List<ClinicResponse>>>;