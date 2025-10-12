using System.Reflection;
using Notifications.Domain.Enums;
using Notifications.Domain.Interfaces;

namespace Notifications.Domain.Entities;

public class InAppNotification : INotification
{
    public string Id { get; set; }
    public required string TourId { get; set; }
    public NotificationTypeEnum Type { get; set; }
    public string Title { get; set; }
    public string DescriptionOfTour { get; set; } = string.Empty;
    public string Content { get; set; }
    public DeliveryStatusEnum Status { get; set; }
    public DateTime OccuredOn { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public DateTime? ReadAt { get; set; }

    // Parameterless constructor for MongoDB serialization
    public InAppNotification()
    {
        Id = string.Empty;
        Title = string.Empty;
        TourId = "Undefined";
        Content = string.Empty;
        Status = DeliveryStatusEnum.None;
        OccuredOn = DateTime.UtcNow;
        CreatedAt = null;
        SentAt = null;
        ReadAt = null;
        DescriptionOfTour = string.Empty;
        Type = NotificationTypeEnum.None;
    }

    public InAppNotification(
        NotificationTypeEnum type,
        string tourId,
        string name,
        DateTime dateOfTour,
        string mountainName,
        string description,
        int minNumberOfPeople,
        int maxNumberOfPeople
    )
    {
        Id = Guid.NewGuid().ToString();
        TourId = tourId;
        Type = type;
        Title = $"New tour {name} to mountain {mountainName} is published!";
        DescriptionOfTour = description;
        Content = $"Join us for an exciting hiking tour! 👥 Group size: {minNumberOfPeople}-{maxNumberOfPeople} hikers\n📅 Scheduled: {dateOfTour:dddd, MMMM dd, yyyy}\n\n{description}\n\nTap to view details and register!";
        Status = DeliveryStatusEnum.None;
        OccuredOn = DateTime.UtcNow;
        CreatedAt = null;
        SentAt = null;
        ReadAt = null;
    }


    public void MarkAsFailed()
    {
        Status = DeliveryStatusEnum.Failed;
    }

    public bool CanBeRetried()
    {
        return Status == DeliveryStatusEnum.Failed;
    }

    public void MarkAsSent(DateTime sentAt)
    {
        if (Status == DeliveryStatusEnum.Failed)
            throw new InvalidOperationException("Cannot mark failed notification as sent");

        Status = DeliveryStatusEnum.Sent;
        SentAt = sentAt;
    }

    public void MarkAsRead(DateTime readAt)
    {
        if (Status != DeliveryStatusEnum.Sent)
            throw new InvalidOperationException("Only sent notifications can be marked as read");

        Status = DeliveryStatusEnum.Read;
        ReadAt = readAt;
    }

}
