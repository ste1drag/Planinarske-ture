public interface INotification
{
    Guid Guid { get; }
    string UserId {get; }
    NotificationType Type { get; }
    string Subject {get; }
    string Body {get; }
    DeliveryStatus Status {get; }
    DateTime CreatedAt {get; }
    List<DeliveryAttempts> DeliveryAttempts {get; }
}
