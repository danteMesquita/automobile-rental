using AutomobileRentalManagementAPI.Infra.Contexts;
using AutomobileRentalManagementAPI.Infra.Contexts.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutomobileRentalManagementAPI.Ioc
{
    public static class DependencyInjection
    {
        private const string ConnectionString = "PostgresConnection";

        public static IServiceCollection AddInfraData(this IServiceCollection services) =>
        services
            .AddContext()
            //.AddRepositories()
            //.AddServices()
            .AddScoped<IDbConnectionFactory, NpgConnectionFactory>();


        private static IServiceCollection AddContext(this IServiceCollection services)
        {
            var connectionString = services.BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(ConnectionString);

            services
                .AddDbContext<RentalDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}