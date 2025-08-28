using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotification
{
    public class GetInAppNotificationQuery : IRequest<InAppNotificationResponse?>
    {
        public string Id { get; set; } = null!;
    }
}
