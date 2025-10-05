using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Notifications.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        Action<IServiceCollection> configureInfrastructureServices
    )
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(typeof(Mapper));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        configureInfrastructureServices(services);

        return services;
    }
}
