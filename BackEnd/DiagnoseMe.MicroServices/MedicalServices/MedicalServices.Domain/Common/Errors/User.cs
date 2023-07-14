using ErrorOr;

namespace MedicalServices.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        
        public static Error SomethingWentWrong => Error.Failure(
            code: "User.SomethingWentWrong",
            description: "Something went wrong."
        );
        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found."
        );

        public static Error YouCanNotDoThis => Error.Validation(
            code: "User.YouCanNotDoThis",
            description: "You are not Authorized to do this."
        );

        public static Error AlreadyExists => Error.Validation(
            code: "User.AlreadyExists",
            description: "User already exists."
        );
        public static Error AddFailed => Error.Failure(
            code: "User.AddFailed",
            description: "Failed to add user."
        );

        public static Error UpdateFailed => Error.Failure(
            code: "User.UpdateFailed",
            description: "Failed to update user."
        );
        public static Error DeleteFailed => Error.Failure(
            code: "User.DeleteFailed",
            description: "Failed to delete user."
        );
    }
}