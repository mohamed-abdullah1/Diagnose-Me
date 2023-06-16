using ErrorOr;

namespace MedicalBlog.Domain.Common.Errors;
public static partial class Errors
{
    public static class Post
    {
        public static Error RatingFailed => Error.Failure(
            code: "Post.RatingFailed",
            description: "Post rating failed."
        );
        public static Error NotFound => Error.NotFound(
            code: "Post.NotFound",
            description: "Post not found."
        );
        public static Error CreationFailed => Error.Failure(
            code: "Post.CreationFailed",
            description: "Post creation failed."
        );

        public static Error DeletionFailed => Error.Failure(
            code: "Post.DeletionFailed",
            description: "Post deletion failed."
        );
        public static Error EditFailed => Error.Failure(
            code: "Post.EditFailed",
            description: "Post edit failed."
        );

        public static Error FailedToAddRating => Error.Failure(
            code: "Post.FailedToAddRating",
            description: "Failed to add rating."
        );

        public static Error TooManyImages => Error.Validation(
            code: "Post.TooManyImages",
            description: "Too many images."
        );

        public static Error AlreadySaved => Error.Validation(
            code: "Post.AlreadySaved",
            description: "Post already saved."
        );

        public static Error NotSaved => Error.Validation(
            code: "Post.NotSaved",
            description: "Post not saved."
        );

        public static Error SaveFailed => Error.Failure(
            code: "Post.SaveFailed",
            description: "Post save failed."
        );

        public static Error UnSaveFailed => Error.Failure(
            code: "Post.UnSaveFailed",
            description: "Post unsave failed."
        );
    }

}