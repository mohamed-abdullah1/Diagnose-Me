namespace BloodDonation.Domain.Common.DonationRequestStatus;

public static class DonationRequestStatus
{
    public const string Pending = "Pending";
    public const string Accepted = "Accepted";
    public const string Rejected = "Rejected";
    public const string PreCompleted = "PreCompleted";
    public const string Completed = "Completed";
    public const string Canceled = "Canceled";

    public static List<string> All => new List<string>
    {
        Pending,
        Accepted,
        Rejected,
        PreCompleted,
        Completed,
        Canceled
    };
}