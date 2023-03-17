using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Patients.Common;

namespace MedicalServices.Application.MedicalServcies.Patients.Queries.GetPatientsByDoctorId;

public record GetPatientsByDoctorIdQuery(
    string DoctorId,
    int PageNumber) : IRequest<ErrorOr<List<PatientResponse>>>;