namespace StaticServe.Common;

public record RMQFileResponse(
    string FilePath,
    string Base64File
);