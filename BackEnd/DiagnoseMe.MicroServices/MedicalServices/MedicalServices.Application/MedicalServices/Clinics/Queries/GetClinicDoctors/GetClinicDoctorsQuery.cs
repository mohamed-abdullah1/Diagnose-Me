using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicDoctors;

public record GetClinicDoctorsQuery(
    string ClinicId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;
