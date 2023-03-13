using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Clinics.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Queries.GetClinics;

public record GetClinicsQuery(
    int PageNumber
) : IRequest<ErrorOr<List<ClinicResponse>>>;