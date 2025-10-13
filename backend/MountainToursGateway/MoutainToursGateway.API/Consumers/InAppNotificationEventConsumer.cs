using MassTransit;
using Microsoft.AspNetCore.SignalR;
using MoutainToursGateway.API.Hubs;
using Shared.Events.Gateway;

namespace MoutainToursGateway.API.Consumers;

public class InAppNotificationEventConsumer : IConsumer<InAppNotificationCreatedTourEvent>
{
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly ILogger<InAppNotificationEventConsumer> _logger;

    public InAppNotificationEventConsumer(
        IHubContext<NotificationHub> hubContext,
        ILogger<InAppNotificationEventConsumer> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<InAppNotificationCreatedTourEvent> context)
    {
        var notification = context.Message;
        _logger.LogInformation("Received notification event: {@Notification}", notification);

        try
        {
            // Push to all connected SignalR clients
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", new
            {
                id = notification.Id,
                title = notification.Title,
                description = notification.DescriptionOfTour,
                content = notification.Content,
                timestamp = notification.Timestamp
            });

            _logger.LogInformation("Notification pushed to SignalR clients: {NotificationId}", notification.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to push notification to SignalR clients");
            throw;
        }
    }
}