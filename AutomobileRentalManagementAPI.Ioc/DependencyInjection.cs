using AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces;
using AutomobileRentalManagementAPI.Application.MessageQueue.Publishers.Motorcycle;
using AutomobileRentalManagementAPI.Domain.Repositories;
using AutomobileRentalManagementAPI.Domain.Repositories.Motorcycles;
using AutomobileRentalManagementAPI.Infra.Contexts;
using AutomobileRentalManagementAPI.Infra.Contexts.Impl;
using AutomobileRentalManagementAPI.Infra.MessageQueue.RabbitMq;
using AutomobileRentalManagementAPI.Infra.Repositories;
using AutomobileRentalManagementAPI.Infra.Repositories.Motorcycles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutomobileRentalManagementAPI.Ioc
{
    public static class DependencyInjection
    {
        private const string ConnectionString = "PostgresConnection";

        public static IServiceCollection AddInfraData(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddContext()
            .AddScoped<IDbConnectionFactory, NpgConnectionFactory>()
            .AddRepositories()
            .AddServices()
            .AddRabbitMq(configuration);

        private static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
                .AddScoped(typeof(IMongoRepositoryBase<>), typeof(MongoRepositoryBase<>))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IMotorcycleRepository, MotorcycleRepository>()
                .AddScoped<IMotorcycleMongoRepository, MotorcycleMongoRepository>();

        private static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<IUserPublisher, UserPublisher>()
                .AddScoped<IMotorcyclePublisher, MotorcyclePublisher>();

        private static IServiceCollection AddContext(this IServiceCollection services)
        {
            var connectionString = services.BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(ConnectionString);

            services
                .AddDbContext<RentalDbContext>(options => options.UseNpgsql(connectionString))
                .AddSingleton<MongoDbContextFactory>();

            return services;
        }

        private static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration) =>
            services
                .Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"))
                .AddScoped<IRabbitMqConnection, RabbitMqConnection>();
    }
}