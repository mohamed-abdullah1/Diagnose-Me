
using System;
using System.Runtime.CompilerServices;
using System.Text;
using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalBlog.Application.Authentication.Users.Commands.AddUser;
using MedicalBlog.Application.Authentication.Users.Commands.DeleteUser;
using MedicalBlog.Application.Authentication.Users.Commands.UpdateUser;
using MedicalBlog.Application.Authentication.Users.Common;
using MedicalBlog.Application.Doctors.Commands.UpdateDoctor;
using MedicalBlog.Application.Doctors.Common;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace MedicalBlog.Infrastructure.RabbitMQ;

public class MessageQueueHelper
{
    
    public static Task SubscribeToRegisterUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthAddExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete:  false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete:  false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.MedicalBlogAddingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var userResponse = JsonConvert.DeserializeObject<ApplicationUserResponse>(UserDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            var command = mapper.Map<AddUserCommand>(userResponse!);
            var logger = (ILogger) serviceProvider.GetRequiredService(typeof(ILogger))!;
            try
            {
                var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
                var result = await mediator.Send(command!);
                
                if (result.IsError)
                {
                    Logging(logger, result.Errors);
                }
                else
                {
                    logger.Information(result.Value.Message);
                }
            }
            catch (Exception e)
            {
                
                logger.Error(e.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.MedicalBlogAddingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    public static Task SubscribeToDeleteUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthDeleteExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete:  false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete:  false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.MedicalBlogDeletingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            var command = new DeleteUserCommand(UserDecoded);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
           try
           {     
                var result = await mediator.Send(command!);
                
                if (result.IsError)
                {
                    Logging(logger, result.Errors);
                }
                else
                {
                    logger.Information(result.Value.Message);
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.MedicalBlogDeletingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    public static Task SubscribeToUpdateUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthUpdateExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete:  false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete:  false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.MedicalBlogUpdatingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var userResponse = JsonConvert.DeserializeObject<ApplicationUserResponse>(UserDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            try
            {
                var command = mapper.Map<UpdateUserCommand>(userResponse!);
                var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
                var result = await mediator.Send(command!);
                
                if (result.IsError)
                {
                    Logging(logger, result.Errors);
                }
                else
                {
                    logger.Information(result.Value.Message);
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.MedicalBlogUpdatingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    public static Task SubscribeToUpdateDoctorQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.MedicalServiciesUpdateExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete:  false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalBlogUpdatingDoctorQueue,
            durable: true,
            exclusive: false,
            autoDelete:  false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalBlogUpdatingDoctorQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.MedicalBlogUpdatingDoctorQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var doctorEncoded = eventArgs.Body.ToArray();
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            var doctorDecoded = Encoding.UTF8.GetString(doctorEncoded);
            var doctorResponse = JsonConvert.DeserializeObject<RMQUpdateDoctorResponse>(doctorDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            try
            {
                var command = mapper.Map<UpdateDoctorCommand>(doctorResponse!);
                var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
                var result = await mediator.Send(command!);
                if (result.IsError)
                {
                    Logging(logger, result.Errors);
                }
                else
                {
                    logger.Information(result.Value.Message);
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.MedicalBlogUpdatingDoctorQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }
    private static void Logging (ILogger _logger, List<Error> errors,[CallerMemberName] string callingMethod = "")
    {
        
            _logger.Error(@$"An error has been occured..
                UserId: RabitMQ
                Called Method: {callingMethod}
                TraceId: 
                Errors: [{string.Join(", ", errors.Select(error => error.Description))}]");
    }
    
}
