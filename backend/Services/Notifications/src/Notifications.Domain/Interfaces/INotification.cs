using Notifications.Domain.Enums;

namespace Notifications.Domain.Interfaces;

public interface INotification
{
    string Id { get; set; }
    string UserId { get; set; }
    NotificationTypeEnum Type { get; set; }
    string Content { get; set; }
    DeliveryStatusEnum Status { get; set; }
    DateTime CreatedAt { get; set; }

    void MarkAsDelivered(DateTime deliveredAt);
    void MarkAsFailed(string reason);
    bool CanBeRetried();
}
