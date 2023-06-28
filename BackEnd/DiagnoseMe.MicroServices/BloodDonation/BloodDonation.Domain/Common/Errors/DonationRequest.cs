using ErrorOr;
namespace BloodDonation.Domain.Common.Errors;


public static partial class Errors
{
    public static class DonationRequest
    {
        public static Error SomethingWentWrong => Error.Failure(
            code: "DonationRequest.SomethingWentWrong",
            description: "Something went wrong."
        );
        public static Error NotFound => Error.NotFound(
            code: "DonationRequest.NotFound",
            description: "Donation request not found."
        );
        public static Error YouCanNotDoThis => Error.Validation(
            code: "DonationRequest.YouCanNotDoThis",
            description: "You are not authorized to do this."
        );
        public static Error InvalidStatus => Error.Validation(
            code: "DonationRequest.InvalidStatus",
            description: "Invalid status."
        );
        public static Error InvalidBloodType => Error.Validation(
            code: "DonationRequest.InvalidBloodType",
            description: "Invalid blood type."
        );
        public static Error InvalidLocation => Error.Validation(
            code: "DonationRequest.InvalidLocation",
            description: "Invalid location."
        );
        public static Error InvalidReason => Error.Validation(
            code: "DonationRequest.InvalidReason",
            description: "Invalid reason."
        );
        public static Error SaveFailed => Error.Failure(
            code: "DonationRequest.SaveFailed",
            description: "Donation request save failed."
        );
    }
}