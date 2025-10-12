using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Application.Business
{
    public static class NotificationDeliveryRules
    {


        public static void ApplyCreationRules(InAppNotification notification)
        {
            notification.Status = DeliveryStatusEnum.Pending;
            notification.CreatedAt = DateTime.UtcNow;
        }

        public static void ApplyDeliveryRules(InAppNotification notification, bool isSuccess)
        {
            if (isSuccess)
            {
                notification.MarkAsSent(DateTime.Now);
            }
            else
            {
                notification.MarkAsFailed();
            }
        }
    }
}
