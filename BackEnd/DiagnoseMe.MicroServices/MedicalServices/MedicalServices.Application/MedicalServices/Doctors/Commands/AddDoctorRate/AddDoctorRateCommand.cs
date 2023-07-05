using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctorRate;


public record AddDoctorRateCommand(
    int Rate,
    string? Comment,
    string UserId,
    string DoctorId) : IRequest<ErrorOr<CommandResponse>>;