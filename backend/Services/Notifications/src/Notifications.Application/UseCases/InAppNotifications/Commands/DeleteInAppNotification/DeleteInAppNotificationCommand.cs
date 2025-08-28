using MediatR;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.DeleteInAppNotification
{
    public class DeleteInAppNotificationCommand : IRequest<bool>
    {
        public string Id { get; set; } = null!;
    }
}
