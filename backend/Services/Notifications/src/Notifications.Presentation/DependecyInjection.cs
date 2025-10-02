using Microsoft.Extensions.DependencyInjection;

namespace Notifications.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}
