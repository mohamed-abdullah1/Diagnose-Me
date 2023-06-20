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
            exchange: RabbitMQConstants.AuthDeleteExchange,
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
        channel.QueueDeclare(
            queue: RabbitMQConstants.ChatDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
        
        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.MedicalBlogDeletingUserQueue);

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.MedicalServicesDeletingUserQueue);

        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.BloodDonationDeletingUserQueue);

        channel.QueueBind(
            queue: RabbitMQConstants.NotificationDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.NotificationDeletingUserQueue);
        channel.QueueBind(
            queue: RabbitMQConstants.ChatDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.ChatDeletingUserQueue);
        
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "text/plain";
        props.DeliveryMode = 2;

        byte[] body = Encoding.UTF8.GetBytes(userId);
        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthDeleteExchange,
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
            exchange: RabbitMQConstants.AuthAddExchange, 
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
        
        channel.QueueDeclare(
            queue: RabbitMQConstants.ChatAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueBind(
            queue: RabbitMQConstants.ChatAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.ChatAddingUserQueue
        );
       
        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.MedicalBlogAddingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.MedicalServicesAddingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.BloodDonationAddingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.NotificationAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.NotificationAddingUserQueue
        );

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(user);
        byte[] body = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

    public void UpdateUser(ApplicationUserResponse user)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthUpdateExchange, 
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
        
        channel.QueueDeclare(
            queue: RabbitMQConstants.ChatUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.MedicalBlogUpdatingUserQueue
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.MedicalServicesUpdatingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.BloodDonationUpdatingUserQueue
        );
        channel.QueueBind(
            queue: RabbitMQConstants.NotificationUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.NotificationUpdatingUserQueue
        );

        channel.QueueBind(
            queue: RabbitMQConstants.ChatUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.ChatUpdatingUserQueue
        );

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(user);
        byte[] body = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }
}