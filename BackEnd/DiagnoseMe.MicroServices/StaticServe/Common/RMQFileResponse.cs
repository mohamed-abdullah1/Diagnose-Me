namespace StaticServe.Common;

public record RMQFileResponse(
    string FileName,
    string FilePath,
    IFormFile FileContent
);