using AutomobileRentalManagementAPI.Infra.MessageQueue.RabbitMq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Microsoft.Extensions.DependencyInjection;
using AutomobileRentalManagementAPI.Domain.Repositories;
using AutomobileRentalManagementAPI.Domain.Entities;
using System.Text;
using System.Text.Json;

public class UserConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly RabbitMQSettings _settings;

    public UserConsumer(IServiceProvider serviceProvider, IOptions<RabbitMQSettings> options)
    {
        _serviceProvider = serviceProvider;
        _settings = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.Host,
            Port = _settings.Port,
            UserName = _settings.Username,
            Password = _settings.Password,
            VirtualHost = _settings.VirtualHost
        };

        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: _settings.QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: cancellationToken
        );

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            using var scope = _serviceProvider.CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var user = JsonSerializer.Deserialize<Motorcycle>(message);

            if (user != null)
                await userRepository.AddAsync(user, cancellationToken);
        };

        await channel.BasicConsumeAsync(
            queue: _settings.QueueName,
            autoAck: true,
            consumer: consumer
        );

        await Task.Delay(Timeout.Infinite, cancellationToken);
    }
}
