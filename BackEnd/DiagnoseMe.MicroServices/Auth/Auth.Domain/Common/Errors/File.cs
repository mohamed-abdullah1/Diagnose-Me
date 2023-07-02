using ErrorOr;

namespace Auth.Domain.Common.Errors;

public static partial class Errors
{
    public static class File
    {
        public static Error NotAPicture => Error.Validation(
            code: "File.NotAPicture",
            description: "The file is not a picture."
        );
        public static Error SaveFailed => Error.Validation(
                code: "User.File.SaveFailed",
                description: "File Save Failed");
        public static Error NullOrEmpty => Error.Validation(
            code: "File.NullOrEmpty",
            description: "File is null or empty."
        );
    }
}