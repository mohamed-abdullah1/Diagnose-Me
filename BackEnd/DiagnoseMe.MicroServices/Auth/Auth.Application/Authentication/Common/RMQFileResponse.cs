
namespace Auth.Application.Authentication.Common;

public record RMQFileResponse(
    string FilePath,
    string Base64File
);