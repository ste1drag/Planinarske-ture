using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.UpdateInAppNotification
{
    public class UpdateInAppNotificationCommand : IRequest<InAppNotificationResponse>
    {
        public string Id { get; set; } = null!;
        public UpdateInAppNotificationRequest Request { get; set; } = null!;
    }
}
