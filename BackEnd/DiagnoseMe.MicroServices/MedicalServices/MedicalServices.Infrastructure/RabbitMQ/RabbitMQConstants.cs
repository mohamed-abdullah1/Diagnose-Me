namespace MedicalServices.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string MedicalServicesAddingUserQueue = "Auth.MedicalServices.User.Add";
    public const string MedicalServicesDeletingUserQueue = "Auth.MedicalServices.User.Delete";
    public const string MedicalServicesUpdatingUserQueue = "Auth.MedicalServices.User.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
}