using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctorsByPatientId;

public record GetDoctorsByPatientIdQuery(
    string PatientId,
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;