using MediatR;
using Notifications.Application.Contracts;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.DeleteInAppNotification
{
    public class DeleteInAppNotificationCommandHandler
        : IRequestHandler<DeleteInAppNotificationCommand, bool>
    {
        private readonly IInAppNotificationRepository _repository;

        public DeleteInAppNotificationCommandHandler(IInAppNotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            DeleteInAppNotificationCommand request,
            CancellationToken cancellationToken
        )
        {
            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
