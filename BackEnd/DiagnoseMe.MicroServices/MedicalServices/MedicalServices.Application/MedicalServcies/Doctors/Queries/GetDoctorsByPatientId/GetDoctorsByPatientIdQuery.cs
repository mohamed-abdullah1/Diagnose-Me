using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctorsByPatientId;

public record GetDoctorsByPatientIdQuery(
    string PatientId,
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;