namespace MedicalBlog.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string AddingUserQueue = "MedicalBlog.User.Add";
    public const string DeletingUserQueue = "MedicalBlog.User.Delete";
    public const string UpdatingUserQueue = "MedicalBlog.User.Update";
}