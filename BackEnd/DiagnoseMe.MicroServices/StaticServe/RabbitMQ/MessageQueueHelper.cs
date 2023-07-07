

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
            exchange: RabbitMQConstants.StaticServeSaveExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete:  false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.StaticServeSaveQueue,
            durable: true,
            exclusive: false,
            autoDelete:  false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.StaticServeSaveQueue,
            exchange: RabbitMQConstants.StaticServeSaveExchange,
            routingKey: RabbitMQConstants.StaticServeSaveQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var filesEncoded = eventArgs.Body.ToArray();
            var fileDecoded = Encoding.UTF8.GetString(filesEncoded);
            var filesResponse  = new List<RMQFileResponse>();
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            try
            {
                filesResponse = JsonConvert.DeserializeObject<List<RMQFileResponse>>(fileDecoded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logging(logger, new List<Error>(){FileErrors.FileNotFound});
            }
            
            
            foreach(var fileResponse in filesResponse! )
            {
                var _env = (IWebHostEnvironment) serviceProvider.GetRequiredService(typeof(IWebHostEnvironment))!;
                var dirPath = Path.Combine(_env.ContentRootPath, "Files", Path.GetDirectoryName(fileResponse.FilePath)!);
                var filePath = Path.Combine(_env.ContentRootPath, "Files", fileResponse.FilePath);
                if (!Directory.Exists(dirPath))
                {
                    Logging(logger, new List<Error>(){FileErrors.DirectoryNotFound(dirPath)});
                }
                else{
                    var fileBytes = Convert.FromBase64String(fileResponse.Base64File);
                    try
                    {await File.WriteAllBytesAsync(filePath, fileBytes);}
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
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
            exchange: RabbitMQConstants.StaticServeDeleteExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete:  false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.StaticServeDeleteQueue,
            durable: true,
            exclusive: false,
            autoDelete:  false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.StaticServeDeleteQueue,
            exchange: RabbitMQConstants.StaticServeDeleteExchange,
            routingKey: RabbitMQConstants.StaticServeDeleteQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var filesNameEncoded = eventArgs.Body.ToArray();
            var filesNameDecoded = Encoding.UTF8.GetString(filesNameEncoded);
            var filesNameResponse = new List<string>();
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            try
            {
                filesNameResponse = JsonConvert.DeserializeObject<List<string>>(filesNameDecoded);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logging(logger, new List<Error>(){FileErrors.FileNotFound});
            }
            
            foreach(var fileNameDecoded in filesNameResponse!)
            {    
                var _env = (IWebHostEnvironment) serviceProvider.GetRequiredService(typeof(IWebHostEnvironment))!;
                if(File.Exists(Path.Combine(_env.ContentRootPath, "Files", fileNameDecoded)))
                {
                    File.Delete(Path.Combine(_env.ContentRootPath, "Files", fileNameDecoded));
                }
                else
                {
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
