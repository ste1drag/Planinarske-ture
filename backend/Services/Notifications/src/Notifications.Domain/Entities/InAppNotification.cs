using Notifications.Domain.Enums;
using Notifications.Domain.Interfaces;

namespace Notifications.Domain.Entities;

public class InAppNotification : INotification
{
    public string Id { get; private set; }
    public string UserId { get; private set; }
    public NotificationTypeEnum Type { get; private set; }
    public string Content { get; private set; }
    public DeliveryStatusEnum Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ReadAt { get; private set; }

    public InAppNotification(string userId, NotificationTypeEnum type, string content)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        Type = type;
        Content = content ?? throw new ArgumentNullException(nameof(content));
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
