using Notifications.Domain.Enums;

namespace Notifications.Application.DTOs
{
    public class InAppNotificationResponse
    {
        public string Id { get; set; } = string.Empty;
        public string TourId { get; set; } = string.Empty;
        public NotificationTypeEnum Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string DescriptionOfTour { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DeliveryStatusEnum Status { get; set; }
        public DateTime OccuredOn { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}