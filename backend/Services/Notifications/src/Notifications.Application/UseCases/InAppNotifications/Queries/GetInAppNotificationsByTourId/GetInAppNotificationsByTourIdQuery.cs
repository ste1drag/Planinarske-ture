using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByTourId
{
    public class GetInAppNotificationsByTourIdQuery : IRequest<IEnumerable<InAppNotificationResponse>>
    {
        public string TourId { get; set; } = null!;
    }
}