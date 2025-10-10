using System.Reflection;
using Notifications.Domain.Enums;
using Notifications.Domain.Interfaces;

namespace Notifications.Domain.Entities;

public class InAppNotification : INotification
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public NotificationTypeEnum Type { get; set; }
    public string Title { get; set; } // NEW
    public string Message { get; set; } // NEW
    public string Content { get; set; }
    public DeliveryStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ReadAt { get; set; }
    public string? RelatedEntityId { get; set; }
    public string? RelatedEntityType { get; set; }

    // Parameterless constructor for MongoDB serialization
    public InAppNotification()
    {
        Id = string.Empty;
        Title = string.Empty;
        Message = string.Empty;
        UserId = string.Empty;
        Content = string.Empty;
    }

    public InAppNotification(string userId, NotificationTypeEnum type, string title, string message, string content = "")
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        Type = type;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Content = content;
        Status = DeliveryStatusEnum.Pending;
        CreatedAt = DateTime.UtcNow;
        ReadAt = null;
    }

    public void MarkAsDelivered(DateTime deliveredAt)
    {
        // For in-app notifications, "delivered" means "read"
        if (Status == DeliveryStatusEnum.Failed)
            throw new InvalidOperationException("Cannot mark failed notification as delivered");

        Status = DeliveryStatusEnum.Read;
        ReadAt = deliveredAt;
    }

    public void MarkAsFailed(string reason)
    {
        if (Status == DeliveryStatusEnum.Read)
            throw new InvalidOperationException("Cannot mark read notification as failed");

        Status = DeliveryStatusEnum.Failed;
        // Could add FailureReason property later if needed
    }

    public bool CanBeRetried()
    {
        return Status == DeliveryStatusEnum.Failed;
    }
}
