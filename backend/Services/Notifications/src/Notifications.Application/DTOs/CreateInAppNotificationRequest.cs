using Notifications.Domain.Enums;

namespace Notifications.Application.DTOs;

public class CreateInAppNotificationRequest
{

    public NotificationTypeEnum Type { get; set; }
    public required string Id { get; init; }
    public DateTime OccuredOn { get; init; }

    //DomainPayload
    public required string TourId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public DateTime DateOfTour { get; init; }
    public string? MountainName { get; init; }
    public int MinNumberOfPeople { get; init; }
    public int MaxNumberOfPeople { get; init; }

}