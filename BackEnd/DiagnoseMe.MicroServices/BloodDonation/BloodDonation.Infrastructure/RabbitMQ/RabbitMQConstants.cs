namespace BloodDonation.Infrastructure.RabbitMQ;

public static class RabbitMQConstants
{
    public const string AuthExchange = "Auth";
    public const string AddingUserQueue = "BloodDonation.User.Add";
    public const string DeletingUserQueue = "BloodDonation.User.Delete";
    public const string UpdatingUserQueue = "BloodDonation.User.Update";
}