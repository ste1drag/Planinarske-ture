using Notifications.Domain.Enums;

namespace Notifications.Domain.Interfaces;

public interface INotification
{
    string Id { get; set; }
    NotificationTypeEnum Type { get; set; }
    string Content { get; set; }
    DateTime OccuredOn { get; set; }
    DateTime? CreatedAt { get; set; }
    DateTime? SentAt { get; set; }
    DateTime? ReadAt { get; set; }



}
