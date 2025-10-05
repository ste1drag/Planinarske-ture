using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetAllInAppNotifications
{
    public class GetAllInAppNotificationsQuery
        : IRequest<IEnumerable<InAppNotificationResponse>> { }
}
