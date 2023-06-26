using System.Text;
using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.RabbitMQ;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace BloodDonation.Infrastructure.RabbitMQ;

public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager(IOptions<RabbitMQSettings> rabbitMqSettings)
    {
        
        channel = RabbitMQConnector.ConnectAsync(rabbitMqSettings.Value);

    }

    public void PublishFile(List<RMQFileResponse> rMQFilesResponse)
    {
        Publish(
            exchange: RabbitMQConstants.StaticServeExchange,
            queues: new List<string>() { RabbitMQConstants.StaticServeSaveQueue },
            obj: rMQFilesResponse,
            contentType: "application/json"
        );
    }
    
    public void DeleteFile(List<string> filesPath)
    {
        Publish(
            exchange: RabbitMQConstants.StaticServeExchange,
            queues: new List<string>() { RabbitMQConstants.StaticServeDeleteQueue },
            obj: filesPath,
            contentType: "application/json"
        );
    }

    public void PublishNotification(NotificationResponse notificationResponse)
    {
        Publish(
            exchange: RabbitMQConstants.NotificationExchange,
            queues: new List<string>() { RabbitMQConstants.NotificationQueue },
            obj: notificationResponse,
            contentType: "application/json"
        );
    }

    private void Publish(
        string exchange,
        List<string> queues,
        Object obj,
        string contentType)
    {
        channel.ExchangeDeclare(
            exchange: exchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: false
        );

        foreach (var queue in queues)
        {
            channel.QueueDeclare(
                queue: queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
        }

        foreach (var queue in queues)
        {
            channel.QueueBind(
                queue: queue,
                exchange: exchange,
                routingKey: queue
            );
        }

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = contentType;
        props.DeliveryMode = 2;

        byte[] body = new byte[] { };
        if (contentType == "text/plain")
        {
            body = Encoding.UTF8.GetBytes(obj.ToString()!);
        }
        else{
            string serializedObject = JsonConvert.SerializeObject(obj);
            body = Encoding.UTF8.GetBytes(serializedObject);}

        channel.BasicPublish(
            exchange: exchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

}