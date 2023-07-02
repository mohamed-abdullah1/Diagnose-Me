using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorRatesByDoctorId;

public record GetDoctorRatesByDoctorIdQuery(
    string DoctorId,
    int PageNumber) : IRequest<ErrorOr<PageResponse>>;