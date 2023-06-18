using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;

public static partial class Errors
{
    public static class File
    {
        public static Error NotAPicture => Error.Validation(
            code: "File.NotAPicture",
            description: "The file is not a picture."
        );
        public static Error SizeDoesNotMatch => Error.Validation(
            code: "File.SizeDoesNotMatch",
            description: "The file size does not match."
        );

        public static Error NotADocument => Error.Validation(
            code: "File.NotADocument",
            description: "The file is not a document."
        );

        public static Error NotAllowed => Error.Validation(
            code: "File.NotAllowed",
            description: "The file is not allowed."
        );
    }
}