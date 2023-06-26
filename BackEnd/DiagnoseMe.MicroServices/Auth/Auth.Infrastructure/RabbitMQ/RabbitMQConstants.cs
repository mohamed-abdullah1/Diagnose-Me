namespace Auth.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthAddExchange = "Auth.Add";
    public const string AuthDeleteExchange = "Auth.Delete";
    public const string AuthUpdateExchange = "Auth.Update";
    public const string MedicalBlogAddingUserQueue = "Auth.MedicalBlog.User.Add";
    public const string MedicalBlogDeletingUserQueue = "Auth.MedicalBlog.User.Delete";
    public const string MedicalBlogUpdatingUserQueue = "Auth.MedicalBlog.User.Update";
    public const string MedicalServicesAddingUserQueue = "Auth.MedicalServices.User.Add";
    public const string MedicalServicesDeletingUserQueue = "Auth.MedicalServices.User.Delete";
    public const string MedicalServicesUpdatingUserQueue = "Auth.MedicalServices.User.Update";
    public const string BloodDonationAddingUserQueue = "Auth.BloodDonation.User.Add";
    public const string BloodDonationDeletingUserQueue = "Auth.BloodDonation.User.Delete";
    public const string BloodDonationUpdatingUserQueue = "Auth.BloodDonation.User.Update";
    public const string NotificationAddingUserQueue = "Auth.Notification.User.Add";
    public const string NotificationDeletingUserQueue = "Auth.Notification.User.Delete";
    public const string NotificationUpdatingUserQueue = "Auth.Notification.User.Update";
    public const string ChatAddingUserQueue = "Auth.Chat.User.Add";
    public const string ChatDeletingUserQueue = "Auth.Chat.User.Delete";
    public const string ChatUpdatingUserQueue = "Auth.Chat.User.Update";
    public const string NotificationExchange = "Global.Notification";
    public const string NotificationQueue = "Global.Notification";
    public const string StaticServeExchange = "StaticServe.Exchange";
    public const string StaticServeSaveQueue = "StaticServe.Save";
    public const string StaticServeDeleteQueue = "StaticServe.Delete";
    public static List<string> AddQueues = new List<string>()
    {
        MedicalBlogAddingUserQueue,
        MedicalServicesAddingUserQueue,
        BloodDonationAddingUserQueue,
        NotificationAddingUserQueue,
        ChatAddingUserQueue
    };

    public static List<string> DeleteQueues = new List<string>()
    {
        MedicalBlogDeletingUserQueue,
        MedicalServicesDeletingUserQueue,
        BloodDonationDeletingUserQueue,
        NotificationDeletingUserQueue,
        ChatDeletingUserQueue
    };

    public static List<string> UpdateQueues = new List<string>()
    {
        MedicalBlogUpdatingUserQueue,
        MedicalServicesUpdatingUserQueue,
        BloodDonationUpdatingUserQueue,
        NotificationUpdatingUserQueue,
        ChatUpdatingUserQueue
    };
}