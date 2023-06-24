using ErrorOr;

namespace StaticServe.Common.Errors;

public static class FileErrors
{
    public static Error DirectoryNotFound => Error.Validation(
            code: "Server.DirectoryNotFound",
            description: "Directory not found"
        );
    public static Error FileNotFound => Error.Validation(
            code: "Server.FileNotFound",
            description: "File not found"
        );
}