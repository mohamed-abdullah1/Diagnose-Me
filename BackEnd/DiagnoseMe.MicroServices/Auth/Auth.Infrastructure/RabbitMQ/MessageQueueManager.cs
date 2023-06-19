using System.Text;
using Auth.Application.Authentication.Common;
using Auth.Application.Common.Interfaces.RabbitMQ;
using Auth.Application.MedicalBlog.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace Auth.Infrastructure.RabbitMQ;

public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager(IOptions<RabbitMQSettings> rabbitMqSettings)
    {
        
        channel = RabbitMQConnector.ConnectAsync(rabbitMqSettings.Value);
        
    }

    public void DeleteUser(string userId)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalServicesDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.BloodDonationDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.NotificationDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
        
        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogDeletingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.MedicalBlogDeletingUserQueue);

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesDeletingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.MedicalServicesDeletingUserQueue);

        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationDeletingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.BloodDonationDeletingUserQueue);

        channel.QueueBind(
            queue: RabbitMQConstants.NotificationDeletingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.NotificationDeletingUserQueue);
        
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "text/plain";
        props.DeliveryMode = 2;

        byte[] body = Encoding.UTF8.GetBytes(userId);
        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

    public void PublishNotification(NotificationResponse notificationResponse)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.NotificationExchange, 
            type : ExchangeType.Fanout,
            durable: true,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.NotificationQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueBind(
            queue: RabbitMQConstants.NotificationQueue,
            exchange: RabbitMQConstants.NotificationExchange,
            routingKey: RabbitMQConstants.NotificationQueue
        );
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedNotification = JsonConvert.SerializeObject(notificationResponse);
        byte[] body = Encoding.UTF8.GetBytes(serializedNotification);

        channel.BasicPublish(
            exchange: RabbitMQConstants.NotificationExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

    public void PublishUser(ApplicationUserResponse user)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange, 
            type : ExchangeType.Fanout,
            durable: true,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalServicesAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.BloodDonationAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.NotificationAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
       
        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogAddingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.MedicalBlogAddingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesAddingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.MedicalServicesAddingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationAddingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.BloodDonationAddingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.NotificationAddingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.NotificationAddingUserQueue
        );

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(user);
        byte[] body = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

    public void UpdateUser(ApplicationUserResponse user)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange, 
            type : ExchangeType.Fanout,
            durable: true,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalServicesUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
        channel.QueueDeclare(
            queue: RabbitMQConstants.BloodDonationUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
        channel.QueueDeclare(
            queue: RabbitMQConstants.NotificationUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.MedicalBlogUpdatingUserQueue
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.MedicalServicesUpdatingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.BloodDonationUpdatingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.NotificationUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.NotificationUpdatingUserQueue
        );

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(user);
        byte[] body = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }
}