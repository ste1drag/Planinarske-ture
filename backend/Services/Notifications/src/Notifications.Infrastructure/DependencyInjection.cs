using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using Notifications.Application.Consumers;
using Notifications.Application.Contracts;
using Notifications.Domain.Enums;
using Notifications.Infrastructure.Configuration;
using Notifications.Infrastructure.Repositories;

namespace Notifications.Infrastructure;

public static class DependencyInjection
{
    private static bool _mongoDbConfigured = false;

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Configure MongoDB enum serialization (only once)
        if (!_mongoDbConfigured)
        {
            ConfigureMongoDbEnumSerialization();
            _mongoDbConfigured = true;
        }

        // Configure MongoDB
        services.Configure<MongoDbConfiguration>(
            configuration.GetSection(MongoDbConfiguration.SectionName)
        );

        // Configure RabbitMQ
        var rabbitMqConfig = configuration
            .GetSection(RabbitMQConfigiration.SectionName)
            .Get<RabbitMQConfigiration>()
            ?? throw new InvalidOperationException("RabbitMQ configuration is missing");

        // Register MassTransit with RabbitMQ
        services.AddMassTransit(x =>
        {
            // Register consumers
            x.AddConsumer<TourCreatedEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqConfig.Host, rabbitMqConfig.VirtualHost, h =>
                {
                    h.Username(rabbitMqConfig.UserName);
                    h.Password(rabbitMqConfig.Password);
                });

                // Configure message retry
                cfg.UseMessageRetry(r => r.Immediate(5));

                // Auto-configure endpoints based on consumers
                cfg.ConfigureEndpoints(context);
            });
        });

        // Register repositories
        services.AddScoped<IInAppNotificationRepository, MongoInAppNotificationRepository>();

        return services;
    }

    private static void ConfigureMongoDbEnumSerialization()
    {
        // Apply convention to serialize all enums as strings
        var pack = new ConventionPack
        {
            new EnumRepresentationConvention(BsonType.String)
        };
        ConventionRegistry.Register("EnumStringConvention", pack, t => true);
    }
}