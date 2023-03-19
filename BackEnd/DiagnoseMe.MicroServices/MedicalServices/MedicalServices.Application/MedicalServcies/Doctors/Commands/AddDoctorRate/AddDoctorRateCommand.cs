using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Doctors.Commands.AddDoctorRate;


public record AddDoctorRateCommand(
    int Rate,
    string? Comment,
    string UserId,
    string DoctorId) : IRequest<ErrorOr<CommandResponse>>;