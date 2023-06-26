

using BloodDonation.Application.BloodDonation.Common;

namespace BloodDonation.Application.Common.Interfaces.RabbitMQ;

public interface IMessageQueueManager
{
    void PublishNotification(NotificationResponse notificationResponse);
    void PublishFile(List<RMQFileResponse> rMQFilesResponse);
    void DeleteFile(List<string> filesPath);
}