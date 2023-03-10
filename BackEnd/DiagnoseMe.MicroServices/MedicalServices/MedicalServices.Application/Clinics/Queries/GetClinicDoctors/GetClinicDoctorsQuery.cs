using ErrorOr;
using MediatR;
using MedicalServices.Application.Clinics.Common;

namespace MedicalServices.Application.Clinics.Queries.GetClinicDoctors;

public record GetClinicDoctorsQuery(
    string ClinicId,
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;
