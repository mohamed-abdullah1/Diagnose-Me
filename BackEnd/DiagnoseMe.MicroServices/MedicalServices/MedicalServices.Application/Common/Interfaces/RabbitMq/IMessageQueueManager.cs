
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.Common.Interfaces.RabbitMq;

public interface IMessageQueueManager
{
    void PublishNotification(NotificationResponse notificationResponse);
    void PublishUpdatedDoctor(RMQUpdateDoctorResponse doctor);
    void PublishFile(List<RMQFileResponse> rMQFilesResponse);
    void DeleteFile(List<string> filesPath);
}