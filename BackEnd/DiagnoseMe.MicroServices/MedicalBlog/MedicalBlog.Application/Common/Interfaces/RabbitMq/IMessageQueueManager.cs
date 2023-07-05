
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.Common.Interfaces.RabbitMQ;

public interface IMessageQueueManager
{
    void PublishNotification(NotificationResponse notificationResponse);
    void PublishFile(List<RMQFileResponse> rMQFilesResponse);
    void DeleteFile(List<string> filesPath);
}