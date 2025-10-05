using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByUserId
{
    public class GetInAppNotificationsByUserIdQuery
        : IRequest<IEnumerable<InAppNotificationResponse>>
    {
        public string UserId { get; set; } = null!;
    }
}
