using ErrorOr;

namespace StaticServe.Common.Errors;

public static class FileErrors
{
    public static Error DirectoryNotFound(string dirPath) => Error.Validation(
            code: "Server.DirectoryNotFound",
            description: $"Directory {dirPath} not found"
        );
    public static Error FileNotFound => Error.Validation(
            code: "Server.FileNotFound",
            description: "File not found"
        );
}