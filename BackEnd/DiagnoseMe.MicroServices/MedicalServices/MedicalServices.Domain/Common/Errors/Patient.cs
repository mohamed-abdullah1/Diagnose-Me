using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;

public static partial class Errors
{
    public static class Patient
    {
        public static Error AlreadyExists = Error.Validation(
            code: "Patient.AlreadyExists",
            description: "Patient already exists."
        );

        public static Error AddFailed = Error.Failure(
            code: "Patient.AddFailed",
            description: "Patient add failed."
        );

        public static Error UpdateFailed = Error.Failure(
            code: "Patient.UpdateFailed",
            description: "Patient update failed."
        );

        public static Error DeleteFailed = Error.Failure(
            code: "Patient.DeleteFailed",
            description: "Patient delete failed."
        );

        public static Error NotFound = Error.Validation(
            code: "Patient.NotFound",
            description: "Patient not found."
        );
    }
}