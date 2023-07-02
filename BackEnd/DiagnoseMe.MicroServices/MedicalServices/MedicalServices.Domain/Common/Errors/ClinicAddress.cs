using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;

public static partial class Errors
{
    public static class ClinicAddress
    {
        public static Error NotFound => Error.NotFound(
            code: "Clinic.NotFound",
            description: "Failed to find clinic."
        );
        public static Error UpdateFailed => Error.Failure(
            code: "Clinic.UpdateFailed",
            description: "ffiled to update clinic."
        );
        public static Error AddFailed => Error.Failure(
            code: "Clinic.AddFailed",
            description: "Failed to add clinic."
        );
        public static Error DeleteFailed => Error.Failure(
            code: "Clinic.DeleteFailed",
            description: "Failed to delete clinic."
        );

        public static Error NotAuthorized => Error.Validation(
            code: "Clinic.NotAuthorized",
            description: "You are not authorized to perform this action."
        );

    }
}