
using Auth.Application.MedicalBlog.Common;

namespace Auth.Application.Common.Interfaces.RabbitMQ;

public interface IMessageQueueManager
{
    void PublishUser(ApplicationUserResponse user);
    void DeleteUser(string userId);
    void UpdateUser(ApplicationUserResponse user);
    void PublishNotification(NotificationResponse notificationResponse);
    void PublishFile(List<RMQFileResponse> rMQFilesResponse);
    void DeleteFile(List<string> filesPath);
}