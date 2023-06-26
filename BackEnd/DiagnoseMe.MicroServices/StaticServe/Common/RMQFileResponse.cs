namespace StaticServe.Common;

public record RMQFileResponse(
    string FilePath,
    IFormFile File
);