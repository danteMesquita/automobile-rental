using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces;
using AutomobileRentalManagementAPI.Domain.DomainEntities;
using AutomobileRentalManagementAPI.Infra.MessageQueue.RabbitMq;
using Microsoft.Extensions.Options;

public class UserPublisher : IUserPublisher
{
    private readonly RabbitMQSettings _settings;

    public UserPublisher(IOptions<RabbitMQSettings> options)
    {
        _settings = options.Value;
    }

    public async Task PublishAsync(UserDomain user)
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

        await channel.QueueDeclareAsync(_settings.QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var message = JsonSerializer.Serialize(user);
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: _settings.QueueName,
            body: body);
    }
}
