using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.UpdateCheck;


public record UpdateCheckCommand(
    string UserId,
    List<string> Roles,
    string Id,
    string Name,
    string Type,
    string Data,
    string Report,
    List<Base64File> Base64Files,
    List<string> RemovedImagesUrls): IRequest<ErrorOr<CommandResponse>>;