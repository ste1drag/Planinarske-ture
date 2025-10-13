using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Reviewing.Application.Behaviors;
using Reviewing.Application.Services;
using Reviewing.Infrastructure.Persistence;
using Reviewing.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<ReviewContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddScoped<ReviewRepository>();
    services.AddScoped<LoggingActionFilter>();

    services.AddHttpClient<ITourService, TourService>(client =>
    {
        var toursApiUrl = configuration.GetValue<string>("ToursApiUrl") ?? "http://mountaintoursgateway.api:8084/tours-api";
        client.BaseAddress = new Uri(toursApiUrl);
        client.Timeout = TimeSpan.FromSeconds(30);
    });

    services.AddValidatorsFromAssemblyContaining<CreateDtoValidator>();
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(options =>
        {
            options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
        });
        app.UseSwaggerUI();

        using var scope = app.Services.CreateScope();
        {
            var context = scope.ServiceProvider.GetRequiredService<ReviewContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ReviewContextSeed>>();
            context.Database.Migrate();

            // Only seed if the Reviews table is empty
            if (!context.Reviews.Any())
            {
                ReviewContextSeed.SeedAsync(context, logger).GetAwaiter().GetResult();
            }
        }
    }

    app.UseAuthorization();
    app.MapControllers();
}