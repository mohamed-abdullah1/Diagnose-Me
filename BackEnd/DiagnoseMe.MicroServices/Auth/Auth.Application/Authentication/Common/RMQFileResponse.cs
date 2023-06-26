using Microsoft.AspNetCore.Http;

namespace Auth.Application.Authentication.Common;

public record RMQFileResponse(
    string FilePath,
    IFormFile File
);