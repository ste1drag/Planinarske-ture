using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependecyInjection).Assembly;
        services.AddMediatR(configurtion => configurtion.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}
// Test comment
