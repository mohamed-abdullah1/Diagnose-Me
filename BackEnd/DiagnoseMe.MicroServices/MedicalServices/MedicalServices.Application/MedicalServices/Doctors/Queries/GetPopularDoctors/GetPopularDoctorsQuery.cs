using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetPopularDoctors;

public record GetPopularDoctorsQuery(
    string? Specialization
) : IRequest<ErrorOr<PageResponse>>;