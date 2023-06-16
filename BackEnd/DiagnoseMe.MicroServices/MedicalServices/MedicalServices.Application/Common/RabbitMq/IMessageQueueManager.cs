
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.Common.Interfaces.RabbitMQ;

public interface IMessageQueueManager
{
    void PublishNotification(NotificationResponse notificationResponse);
}