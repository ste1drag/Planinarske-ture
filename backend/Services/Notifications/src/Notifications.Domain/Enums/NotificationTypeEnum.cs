namespace Notifications.Domain.Enums;

public enum NotificationTypeEnum
{
    TourCreated,
    TourCancelled,
    TourUpdated,

    // User-related (basic auth integration)
    Welcome,
    PasswordReset
}
