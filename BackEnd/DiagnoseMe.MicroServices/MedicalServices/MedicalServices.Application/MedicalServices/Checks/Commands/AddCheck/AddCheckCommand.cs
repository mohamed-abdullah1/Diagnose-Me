using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.AddCheck; 

public record AddCheckCommand(
    string Name,
    string Type,
    string Data,
    string Report,
    string? DoctorId,
    string PatientId,
    List<Base64File> Base64Files): IRequest<ErrorOr<CommandResponse>>;