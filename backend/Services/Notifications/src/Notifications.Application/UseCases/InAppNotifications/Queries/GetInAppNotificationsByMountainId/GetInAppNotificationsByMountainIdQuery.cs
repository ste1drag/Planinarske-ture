using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByMountainId
{
    public class GetInAppNotificationsByMountainIdQuery : IRequest<IEnumerable<InAppNotificationResponse>>
    {
        public string MountainId { get; set; } = null!;
    }
}