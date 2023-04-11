using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicDoctors;

public record GetClinicDoctorsQuery(
    string ClinicId,
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;
