using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;

public static partial class Errors
{
    public static class Check
    {
        public static Error SomethingWentWrong => Error.Failure(
            code: "Check.SomethingWentWrong",
            description: "Something went wrong."
        );
        public static Error NotFound => Error.NotFound(
            code: "Check.NotFound",
            description: "Check not found."
        );

        public static Error AddFailed => Error.Failure(
            code: "Check.AddFailed",
            description: "Failed to add check."
        );
        public static Error UpdateFailed => Error.Failure(
            code: "Check.UpdateFailed",
            description: "Failed to update check."
        );
        public static Error DeleteFailed => Error.Failure(
            code: "Check.DeleteFailed",
            description: "Failed to delete check."
        );
    }
}