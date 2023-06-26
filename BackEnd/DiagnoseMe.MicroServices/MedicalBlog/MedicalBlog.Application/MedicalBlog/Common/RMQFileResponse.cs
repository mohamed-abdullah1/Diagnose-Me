using Microsoft.AspNetCore.Http;

namespace MedicalBlog.Application.MedicalBlog.Common;

public record RMQFileResponse(
    string FilePath,
    IFormFile File
);