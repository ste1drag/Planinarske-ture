using Notifications.Domain.Enums;

namespace Presentation.DTOs
{
    public class CreateInAppNotificationRequest
    {
        public string UserId { get; set; } = string.Empty;
        public NotificationTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
