using Notifications.Domain.Enums;

namespace Notifications.Application.DTOs
{
    public class UpdateInAppNotificationRequest
    {
        public NotificationTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
        public DeliveryStatusEnum Status { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
