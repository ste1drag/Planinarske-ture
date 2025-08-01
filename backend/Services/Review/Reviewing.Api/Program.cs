using Microsoft.EntityFrameworkCore;
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