namespace MedicalServices.Application.MedicalServcies.Common;

public record CommandResponse(
    bool Success,
    string Message,
    string Path
);