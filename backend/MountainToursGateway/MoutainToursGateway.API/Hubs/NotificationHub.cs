using Microsoft.AspNetCore.SignalR;

namespace MoutainToursGateway.API.Hubs;

public class NotificationHub : Hub
{
    private readonly ILogger<NotificationHub> _logger;
    private static int _connectionCount = 0;

    public NotificationHub(ILogger<NotificationHub> logger)
    {
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        _connectionCount++;
        var userId = Context.User?.Identity?.Name ?? "Anonymous";
        _logger.LogInformation("Client connected: {ConnectionId}, User: {UserId}, Total Connections: {Count}",
            Context.ConnectionId, userId, _connectionCount);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        _connectionCount--;
        _logger.LogInformation("Client disconnected: {ConnectionId}, Total Connections: {Count}",
            Context.ConnectionId, _connectionCount);
    }
}