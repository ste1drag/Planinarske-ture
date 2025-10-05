using Notifications.Domain.Enums;

namespace Notifications.Application.DTOs
{
    public class CreateInAppNotificationRequest
    {
        public string UserId { get; set; } = string.Empty;
        public NotificationTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
