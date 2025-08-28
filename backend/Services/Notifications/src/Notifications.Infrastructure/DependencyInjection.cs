using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.Domain.Interfaces;
using Notifications.Infrastructure.Configuration;
using Notifications.Infrastructure.Repositories;

namespace Notifications.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Configure MongoDB
        services.Configure<MongoDbConfiguration>(
            configuration.GetSection(MongoDbConfiguration.SectionName)
        );

        // Register repositories
        services.AddScoped<IInAppNotificationRepository, MongoInAppNotificationRepository>();

        return services;
    }
}
