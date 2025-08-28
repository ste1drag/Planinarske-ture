using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification
{
    public class CreateInAppNotificationCommand : IRequest<InAppNotificationResponse>
    {
        public CreateInAppNotificationRequest Request { get; set; } = null!;
    }
}
