using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Clinics.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Queries.GetClinicDoctors;

public record GetClinicDoctorsQuery(
    string ClinicId,
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;
