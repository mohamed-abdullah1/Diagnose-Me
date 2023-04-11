namespace MedicalServices.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string AddingUserQueue = "MedicalServices.User.Add";
    public const string DeletingUserQueue = "MedicalServices.User.Delete";
    public const string UpdatingUserQueue = "MedicalServices.User.Update";
}