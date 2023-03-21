
namespace Auth.Application.Common.Interfaces.RabbitMq;

public interface IMessageQueueManager
{
    void PublishUser(ApplicationUserResponse user);
    void DeleteUser(string userId);
    void UpdateUser(ApplicationUserResponse user);
}