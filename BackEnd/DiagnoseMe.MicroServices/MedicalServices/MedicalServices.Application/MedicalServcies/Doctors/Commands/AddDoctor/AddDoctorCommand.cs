using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctor;


public record AddDoctorCommand(
    string UserId,
    string Title,
    string Bio,
    string License,
    string ClinicId
) : IRequest<ErrorOr<CommandResponse>>;
