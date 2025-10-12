using System;

namespace Shared.Events.Gateway;

public class InAppNotificationCreatedTourEvent
{
    public Guid Id { get; init; }
    public DateTime Timestamp { get; init; }

    public required string Title { get; set; }
    public required string DescriptionOfTour { get; set; } = string.Empty;
    public required string Content { get; set; }
}
