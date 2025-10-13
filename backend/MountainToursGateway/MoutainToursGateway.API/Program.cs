using MassTransit;
using MoutainToursGateway.API.Consumers;
using MoutainToursGateway.API.Hubs;
using Shared.Events.Gateway;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

<<<<<<< HEAD
// Add CORS
=======
// Add CORS for frontend
>>>>>>> origin/features/notifications
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
<<<<<<< HEAD
        policy.WithOrigins("http://localhost:3000")
=======
        policy.WithOrigins("http://localhost:5173",
                             "https://gourav-d.github.io")
>>>>>>> origin/features/notifications
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("authenticated", policy =>
        policy.RequireAuthenticatedUser());
});

// Add MassTransit with RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<InAppNotificationEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        // Use configuration - will read from appsettings or environment variables
        var rabbitHost = builder.Configuration["RabbitMq:Host"] ?? "localhost";
        var rabbitUser = builder.Configuration["RabbitMq:Username"] ?? "guest";
        var rabbitPass = builder.Configuration["RabbitMq:Password"] ?? "guest";

        cfg.Host(rabbitHost, "/", h =>
        {
            h.Username(rabbitUser);
            h.Password(rabbitPass);
        });

        cfg.ReceiveEndpoint("gateway-notification-queue", e =>
        {
            e.ConfigureConsumer<InAppNotificationEventConsumer>(context);
        });
    });
});


builder.Services.AddSignalR();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD
// Use CORS before other middleware
=======

>>>>>>> origin/features/notifications
app.UseCors("AllowFrontend");

app.MapReverseProxy();


app.MapHub<NotificationHub>("/notificationHub");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();