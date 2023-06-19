namespace BloodDonation.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string BloodDonationAddingUserQueue = "Auth.BloodDonation.User.Add";
    public const string BloodDonationDeletingUserQueue = "Auth.BloodDonation.User.Delete";
    public const string BloodDonationUpdatingUserQueue = "Auth.BloodDonation.User.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
}