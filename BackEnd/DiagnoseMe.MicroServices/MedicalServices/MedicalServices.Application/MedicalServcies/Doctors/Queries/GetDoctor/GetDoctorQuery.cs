using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctor;


public record GetDoctorQuery(
    string DoctorId) : IRequest<ErrorOr<DoctorResponse>>;