using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Application.Business
{
    public static class NotificationDeliveryRules
    {
        /// <summary>
        /// Determines if a notification should be delivered based on business rules
        /// </summary>
        public static bool ShouldDeliverNotification(InAppNotification notification)
        {
            // Business rule: Don't deliver notifications that are already read
            if (notification.Status == DeliveryStatusEnum.Read)
                return false;

            // Business rule: Don't deliver failed notifications
            if (notification.Status == DeliveryStatusEnum.Failed)
                return false;

            // Business rule: High priority notifications should always be delivered
            if (
                notification.Type == NotificationTypeEnum.TourCancelled
                || notification.Type == NotificationTypeEnum.PasswordReset
            )
                return true;

            // Business rule: Don't deliver old notifications (older than 7 days)
            if (DateTime.UtcNow - notification.CreatedAt > TimeSpan.FromDays(7))
                return false;

            // Default: deliver the notification
            return true;
        }

        /// <summary>
        /// Determines the delivery priority based on notification type
        /// </summary>
        public static int GetDeliveryPriority(NotificationTypeEnum type)
        {
            return type switch
            {
                NotificationTypeEnum.TourCancelled => 1, // Highest priority
                NotificationTypeEnum.PasswordReset => 2, // High priority
                NotificationTypeEnum.TourUpdated => 3, // Normal priority
                NotificationTypeEnum.TourCreated => 4, // Normal priority
                NotificationTypeEnum.Welcome => 5, // Lowest priority
                _ => 6, // Default lowest priority
            };
        }

        /// <summary>
        /// Determines if a notification should be marked as read automatically
        /// </summary>
        public static bool ShouldAutoMarkAsRead(InAppNotification notification)
        {
            // Business rule: Auto-mark welcome notifications as read after 24 hours
            if (
                notification.Type == NotificationTypeEnum.Welcome
                && DateTime.UtcNow - notification.CreatedAt > TimeSpan.FromHours(24)
            )
                return true;

            return false;
        }

        /// <summary>
        /// Validates notification content based on type
        /// </summary>
        public static bool IsValidNotificationContent(NotificationTypeEnum type, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return false;

            return type switch
            {
                NotificationTypeEnum.TourCancelled => content.Length >= 10, // Cancellations need detailed content
                NotificationTypeEnum.PasswordReset => content.Length >= 5, // Password reset needs some detail
                NotificationTypeEnum.TourUpdated => content.Length >= 5, // Updates need some detail
                _ => content.Length >= 1, // Others just need any content
            };
        }

        /// <summary>
        /// Applies business rules when creating a notification
        /// </summary>
        public static void ApplyCreationRules(InAppNotification notification)
        {
            // Business rule: Set initial status based on type
            if (notification.Type == NotificationTypeEnum.TourCancelled)
            {
                notification.Status = DeliveryStatusEnum.Pending; // High priority, ensure delivery
            }
            else
            {
                notification.Status = DeliveryStatusEnum.Pending;
            }

            // Business rule: Validate content requirements
            if (!IsValidNotificationContent(notification.Type, notification.Content))
            {
                throw new ArgumentException(
                    $"Invalid content for notification type {notification.Type}"
                );
            }
        }

        /// <summary>
        /// Applies business rules when updating a notification
        /// </summary>
        public static void ApplyUpdateRules(InAppNotification notification)
        {
            // Business rule: Once read, cannot be changed back to pending
            if (notification.Status == DeliveryStatusEnum.Read)
            {
                // Allow only status changes
                // Content updates are not allowed for read notifications
            }

            // Business rule: Failed notifications can be retried
            if (notification.Status == DeliveryStatusEnum.Failed)
            {
                notification.Status = DeliveryStatusEnum.Pending;
            }

            // Business rule: Auto-mark as read if conditions are met
            if (ShouldAutoMarkAsRead(notification) && notification.ReadAt == null)
            {
                notification.ReadAt = DateTime.UtcNow;
                notification.Status = DeliveryStatusEnum.Read;
            }
        }
    }
}
