using AutoMapper;
using MediatR;
using Notifications.Domain.Interfaces;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.UpdateInAppNotification
{
    public class UpdateInAppNotificationCommandHandler
        : IRequestHandler<UpdateInAppNotificationCommand, InAppNotificationResponse?>
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public UpdateInAppNotificationCommandHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InAppNotificationResponse?> Handle(
            UpdateInAppNotificationCommand request,
            CancellationToken cancellationToken
        )
        {
            var existingNotification = await _repository.GetByIdAsync(request.Id);
            if (existingNotification == null)
                return null;

            // Update the notification properties
            existingNotification.Type = request.Request.Type;
            existingNotification.Content = request.Request.Content;
            existingNotification.Status = request.Request.Status;
            existingNotification.ReadAt = request.Request.ReadAt;

            var updatedNotification = await _repository.UpdateAsync(existingNotification);
            if (updatedNotification == null)
                return null;

            return _mapper.Map<InAppNotificationResponse>(updatedNotification);
        }
    }
}
