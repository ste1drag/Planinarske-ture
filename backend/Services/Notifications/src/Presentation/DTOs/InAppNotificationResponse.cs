using Notifications.Domain.Enums;

namespace Presentation.DTOs
{
    public class InAppNotificationResponse
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public NotificationTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
        public DeliveryStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
