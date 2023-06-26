using Microsoft.AspNetCore.Http;

namespace MedicalServices.Application.MedicalServices.Common;

public record RMQFileResponse(
    string FilePath,
    IFormFile File
);