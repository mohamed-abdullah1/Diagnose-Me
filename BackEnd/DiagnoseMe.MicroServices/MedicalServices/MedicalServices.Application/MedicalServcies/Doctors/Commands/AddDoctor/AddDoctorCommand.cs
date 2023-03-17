using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctor;


public record AddDoctorCommand(
    string UserId,
    string Title,
    string Bio,
    string License,
    string ClinicId
) : IRequest<ErrorOr<CommandResponse>>;
