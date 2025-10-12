using System;

namespace Notifications.Infrastructure.Configuration;

public class RabbitMQConfigiration
{
    public const string SectionName = "RabbitMq";

    public string Host { get; set; } = "localhost";
    public string VirtualHost { get; set; } = "/";
    public string Password { get; set; } = "guest";
    public string UserName { get; set; } = "guest";
    public int Port { get; set; } = 5672;
}
