

using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ErrorOr;
using StaticServe.Common;
using System.Runtime.CompilerServices;
using System.Text;
using StaticServe.Common.Errors;

namespace StaticServe.RabbitMQ;

public class MessageQueueHelper
{
    
    public static Task SubscribeToSaveQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.StaticServeExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.StaticServeSaveQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.StaticServeSaveQueue,
            exchange: RabbitMQConstants.StaticServeExchange,
            routingKey: RabbitMQConstants.StaticServeSaveQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var filesEncoded = eventArgs.Body.ToArray();
            var fileDecoded = Encoding.UTF8.GetString(filesEncoded);
            var filesResponse = JsonConvert.DeserializeObject<List<RMQFileResponse>>(fileDecoded);
            
            
            foreach(var fileResponse in filesResponse! )
            {
                string filePath =  Path.Combine(AppContext.BaseDirectory, "Files",fileResponse!.FilePath);
                IFormFile file = fileResponse!.File;
                if (!Directory.Exists(filePath))
                {
                    var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
                    Logging(logger, new List<Error>(){FileErrors.DirectoryNotFound});
                }
                else{
                    using (var stream = new FileStream(Path.Combine(filePath,fileResponse.File.Name), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.StaticServeSaveQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    public static void SubscribeToDeleteQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.StaticServeExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.StaticServeDeleteQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.StaticServeDeleteQueue,
            exchange: RabbitMQConstants.StaticServeExchange,
            routingKey: RabbitMQConstants.StaticServeDeleteQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var filesNameEncoded = eventArgs.Body.ToArray();
            var filesNameDecoded = Encoding.UTF8.GetString(filesNameEncoded);
            var filesNameResponse = JsonConvert.DeserializeObject<List<string>>(filesNameDecoded);

            foreach(var fileNameDecoded in filesNameResponse!)
            {    
                if(File.Exists(Path.Combine(AppContext.BaseDirectory, "Files", fileNameDecoded)))
                {
                    File.Delete(Path.Combine(AppContext.BaseDirectory, "Files", fileNameDecoded));
                }
                else
                {
                    var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
                    Logging(logger, new List<Error>(){FileErrors.FileNotFound});
                }
            }
            await Task.CompletedTask;
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.StaticServeDeleteQueue,
            autoAck: false,
            consumer: consumer
        );
    }

    private static void Logging (Serilog.ILogger _logger, List<Error> errors,[CallerMemberName] string callingMethod = "")
    {
        
            _logger.Error(@$"An error has been occured..
                UserId: RabitMQ
                Called Method: {callingMethod}
                TraceId: 
                Errors: [{string.Join(", ", errors.Select(error => error.Description))}]");
    }
}
