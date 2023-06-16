
using Auth.Application.MedicalBlog.Common;

namespace Auth.Application.Common.Interfaces.RabbitMQ;

public interface IMessageQueueManager
{
    void PublishUser(ApplicationUserResponse user);
    void DeleteUser(string userId);
    void UpdateUser(ApplicationUserResponse user);
    void PublishNotification(NotificationResponse notificationResponse);
}