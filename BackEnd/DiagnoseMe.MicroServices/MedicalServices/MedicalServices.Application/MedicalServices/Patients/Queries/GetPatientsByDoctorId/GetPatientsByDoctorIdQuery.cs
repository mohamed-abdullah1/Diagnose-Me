using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Queries.GetPatientsByDoctorId;

public record GetPatientsByDoctorIdQuery(
    string DoctorId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;