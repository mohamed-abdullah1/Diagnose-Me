using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;


public static partial class Errors
{
    public static class PatientDoctor
    {
        public static Error AlreadyExists = Error.Validation(
            code: "PatientDoctor.AlreadyExists",
            description: "PatientDoctor already exists."
        );

        public static Error AddFailed = Error.Failure(
            code: "PatientDoctor.AddFailed",
            description: "PatientDoctor add failed."
        );

        public static Error AlreadyLinked = Error.Validation(
            code: "PatientDoctor.AlreadyLinked",
            description: "PatientDoctor already linked."
        );
        public static Error DeleteFailed = Error.Failure(
            code: "PatientDoctor.DeleteFailed",
            description: "PatientDoctor delete failed."
        );

        public static Error NotFound = Error.Validation(
            code: "PatientDoctor.NotFound",
            description: "PatientDoctor not found."
        );
    }
}