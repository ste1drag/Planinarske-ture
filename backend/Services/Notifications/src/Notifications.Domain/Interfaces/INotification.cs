
using Notifications.Domain.Enums;

namespace Notifications.Domain.Interfaces;

public interface INotification
{
    string Id { get; }
    string UserId { get; }
    NotificationTypeEnum Type { get; }
    string Content { get; }
    DeliveryStatusEnum Status { get; }
    DateTime CreatedAt { get; }


    void MarkAsDelivered(DateTime deliveredAt);
    void MarkAsFailed(string reason);
    bool CanBeRetried();
}
