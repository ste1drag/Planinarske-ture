using Notifications.Infrastructure;
using Notifications.Application;
using Notifications.Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("🔧 Adding Application services...");
builder.Services.AddApplicationServices(services =>
{
    Console.WriteLine("🔧 Adding Infrastructure services...");
    services.AddInfrastructure(builder.Configuration);
    Console.WriteLine("✅ Infrastructure services added");
});
Console.WriteLine("✅ Application services added");

Console.WriteLine("🔧 Adding Presentation services...");
builder.Services.AddPresentation();
Console.WriteLine("✅ Presentation services added");

builder.Host.UseSerilog(
    (context, services, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
);

Console.WriteLine("🏗️ Building application...");
var app = builder.Build();
Console.WriteLine("✅ Application built successfully");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("🔧 Configuring development environment...");
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    Console.WriteLine("✅ Development environment configured");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

Console.WriteLine("🚀 Starting application...");
app.Run();
