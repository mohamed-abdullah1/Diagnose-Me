using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Queries.GetDoctors;


public record GetDoctorsQuery(
    int PageNumber) : IRequest<ErrorOr<List<DoctorResponse>>>;