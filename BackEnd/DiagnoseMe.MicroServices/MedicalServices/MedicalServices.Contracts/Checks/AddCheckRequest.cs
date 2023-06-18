using MedicalServices.Contracts.Common;

namespace MedicalServices.Contracts.Checks;

public record AddCheckRequest(
    string Name,
    string Type,
    string Data,
    string Report,
    string? DoctorId,
    string PatientId,
    List<Base64File> Base64Files
);
