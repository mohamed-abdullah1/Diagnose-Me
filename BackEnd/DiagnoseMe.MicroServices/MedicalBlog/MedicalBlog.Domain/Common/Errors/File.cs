using ErrorOr;

namespace MedicalBlog.Domain.Common.Errors;

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
            description: "The file size Should be between 10KB and 5MB."
        );
    }
}