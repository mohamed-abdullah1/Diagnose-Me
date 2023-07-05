using MedicalServices.Contracts.Common;

namespace MedicalServices.Contracts.Checks;


public record UpdateCheckRequest(
    string Id,
    string Name,
    string Type,
    string Data,
    string Report,
    string PatientId,
    string? DoctorId,
    List<Base64File> Base64Files,
    List<string> RemovedImagesUrls);