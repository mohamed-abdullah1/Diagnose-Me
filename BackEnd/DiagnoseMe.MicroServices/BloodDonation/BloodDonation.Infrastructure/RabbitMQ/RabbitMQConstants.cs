namespace BloodDonation.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string AddingUserQueue = "Auth.User.Add";
    public const string DeletingUserQueue = "Auth.User.Delete";
    public const string UpdatingUserQueue = "Auth.User.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
}