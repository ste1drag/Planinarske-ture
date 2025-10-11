using Notifications.Infrastructure;
using Notifications.Application;
using Notifications.Presentation;
using Serilog;

// Configure Serilog FIRST, before anything else
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/notifications-.txt", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

// Now configure Serilog with full configuration
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/notifications-.txt", rollingInterval: RollingInterval.Day));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Information("🔧 Adding Application services...");
builder.Services.AddApplicationServices(services =>
{
    Log.Information("🔧 Adding Infrastructure services...");
    services.AddInfrastructure(builder.Configuration);
    Log.Information("✅ Infrastructure services added");
});
Log.Information("✅ Application services added");

Log.Information("🔧 Adding Presentation services...");
builder.Services.AddPresentation();
Log.Information("✅ Presentation services added");

Log.Information("🏗️ Building application...");
var app = builder.Build();
Log.Information("✅ Application built successfully");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Log.Information("🔧 Configuring development environment...");
    app.UseSwagger();
    app.UseSwaggerUI();
    Log.Information("✅ Development environment configured");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSerilogRequestLogging();

try
{
    Log.Information("🚀 Starting Notifications API...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "❌ Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}