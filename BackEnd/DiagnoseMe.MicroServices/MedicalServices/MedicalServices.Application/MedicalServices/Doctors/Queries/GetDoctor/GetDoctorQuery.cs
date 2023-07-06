using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctor;


public record GetDoctorQuery(
    string DoctorId) : IRequest<ErrorOr<DoctorResponse>>;