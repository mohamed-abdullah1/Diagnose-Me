using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetPatientsByDoctorId;

public record GetPatientsByDoctorIdQuery(
    string DoctorId,
    int PageNumber) : IRequest<ErrorOr<List<PatientResponse>>>;