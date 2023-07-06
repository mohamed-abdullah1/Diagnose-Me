namespace MedicalBlog.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthAddExchange = "Auth.Add";
    public const string AuthDeleteExchange = "Auth.Delete";
    public const string AuthUpdateExchange = "Auth.Update";
    public const string MedicalBlogAddingUserQueue = "Auth.MedicalBlog.User.Add";
    public const string MedicalBlogDeletingUserQueue = "Auth.MedicalBlog.User.Delete";
    public const string MedicalBlogUpdatingUserQueue = "Auth.MedicalBlog.User.Update";
    public const string MedicalServiciesUpdateExchange = "MedicalServicies.Update";
    public const string MedicalBlogUpdatingDoctorQueue = "MedicalServicies.MedicalBlog.Doctor.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
    public const string StaticServeSaveExchange = "StaticServe.Save.Exchange";
    public const string StaticServeDeleteExchange = "StaticServe.Delete.Exchange";
    public const string StaticServeSaveQueue = "StaticServe.Save";
    public const string StaticServeDeleteQueue = "StaticServe.Delete";
}