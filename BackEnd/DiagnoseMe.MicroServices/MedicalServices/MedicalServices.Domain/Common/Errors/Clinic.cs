using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;

public static partial class Errors
{
    public static class Clinic
    {
        public static Error SomethingWentWrong => Error.Failure(
            code: "Clinic.SomethingWentWrong",
            description: "Something went wrong."
        );
        public static Error NotFound => Error.NotFound(
            code: "Clinic.NotFound",
            description: "Clinic not found."
        );
        public static Error Exists => Error.Validation(
            code: "Clinic.Exists",
            description: "Clinic already exists."
        );
        public static Error AddFailed => Error.Failure(
            code: "Clinic.AddFailed",
            description: "Failed to add clinic."
        );
        public static Error UpdateFailed => Error.Failure(
            code: "Clinic.UpdateFailed",
            description: "Failed to update clinic."
        );
        public static Error DeleteFailed => Error.Failure(
            code: "Clinic.DeleteFailed",
            description: "Failed to delete clinic."
        );
    }
}