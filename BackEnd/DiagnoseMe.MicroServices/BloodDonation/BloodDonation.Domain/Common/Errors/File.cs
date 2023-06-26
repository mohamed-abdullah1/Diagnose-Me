using ErrorOr;

namespace BloodDonation.Domain.Common.Errors;

public static partial class Errors
{
    public static class File
    {
        public static Error NotAPicture => Error.Validation(
            code: "File.NotAPicture",
            description: "The file is not a picture."
        );

        public static Error NullOrEmpty => Error.Validation(
            code: "File.NullOrEmpty",
            description: "The file is null or empty."
        );
    }
}