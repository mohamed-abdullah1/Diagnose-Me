namespace BloodDonation.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthAddExchange = "Auth.Add";
    public const string AuthDeleteExchange = "Auth.Delete";
    public const string AuthUpdateExchange = "Auth.Update";
    public const string BloodDonationAddingUserQueue = "Auth.BloodDonation.User.Add";
    public const string BloodDonationDeletingUserQueue = "Auth.BloodDonation.User.Delete";
    public const string BloodDonationUpdatingUserQueue = "Auth.BloodDonation.User.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
    public const string StaticServeExchange = "StaticServe.Exchange";
    public const string StaticServeSaveQueue = "StaticServe.Save";
    public const string StaticServeDeleteQueue = "StaticServe.Delete";

}