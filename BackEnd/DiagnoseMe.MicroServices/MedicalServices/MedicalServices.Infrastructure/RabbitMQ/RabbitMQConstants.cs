namespace MedicalServices.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthAddExchange = "Auth.Add";
    public const string AuthDeleteExchange = "Auth.Delete";
    public const string AuthUpdateExchange = "Auth.Update";
    public const string MedicalServicesAddingUserQueue = "Auth.MedicalServices.User.Add";
    public const string MedicalServicesDeletingUserQueue = "Auth.MedicalServices.User.Delete";
    public const string MedicalServicesUpdatingUserQueue = "Auth.MedicalServices.User.Update";
    public const string MedicalServiciesUpdateExchange = "MedicalServicies.Update";
    public const string MedicalServiciesMedicalBlogUpdatingDoctorQueue = "MedicalServicies.MedicalBlog.Doctor.Update";
    public const string MedicalServicesChatUpdatingDoctorQueue = "MedicalServicies.Chat.Doctor.Update";
    public const string NotificationExchange = "Notification";
    public const string NotificationQueue = "Global.Notification";
    public const string StaticServeExchange = "StaticServe.Exchange";
    public const string StaticServeSaveQueue = "StaticServe.Save";
    public const string StaticServeDeleteQueue = "StaticServe.Delete";
}