namespace MedicalBlog.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string MedicalBlogAddingUserQueue = "Auth.MedicalBlog.User.Add";
    public const string MedicalBlogDeletingUserQueue = "Auth.MedicalBlog.User.Delete";
    public const string MedicalBlogUpdatingUserQueue = "Auth.MedicalBlog.User.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
}