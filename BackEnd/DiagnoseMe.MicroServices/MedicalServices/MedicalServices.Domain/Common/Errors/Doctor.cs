
using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;


public static partial class Errors
{
    public static class Doctor
    {
        public static Error AddFailed => Error.Failure(
            code: "Doctor.AddFailed",
            description: "Failed to add doctor."
        );
        public static Error UpdateFailed => Error.Failure(
            code: "Doctor.UpdateFailed",
            description: "Failed to update doctor."
        );

        public static Error DeleteFailed => Error.Failure(
            code: "Doctor.DeleteFailed",
            description: "Failed to delete doctor."
        );

        public static Error NotFound => Error.NotFound(
            code: "Doctor.NotFound",
            description: "Doctor not found."
        );
    }
}