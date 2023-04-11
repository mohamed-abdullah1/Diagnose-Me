namespace MedicalServices.Application.MedicalServices.Common;

public record CommandResponse(
    bool Success,
    string Message,
    string Path
);