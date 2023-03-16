using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Queries.GetDoctors;


public record GetDoctorsQuery(
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;