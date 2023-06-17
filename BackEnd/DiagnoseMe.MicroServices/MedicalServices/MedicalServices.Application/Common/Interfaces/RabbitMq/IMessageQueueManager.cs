
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.Common.Interfaces.RabbitMq;

public interface IMessageQueueManager
{
    void PublishNotification(NotificationResponse notificationResponse);
}