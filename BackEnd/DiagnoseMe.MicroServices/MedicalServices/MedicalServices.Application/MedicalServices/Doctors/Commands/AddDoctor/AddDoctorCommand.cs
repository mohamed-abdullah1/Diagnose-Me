using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctor;


public record AddDoctorCommand(
    string UserId,
    string Title,
    string Bio,
    string License,
    string ClinicId
) : IRequest<ErrorOr<CommandResponse>>;
