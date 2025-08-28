using AutoMapper;
using MediatR;
using Notifications.Application.Business;
using Notifications.Application.DTOs;
using Notifications.Domain.Entities;
using Notifications.Domain.Interfaces;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification
{
    public class CreateInAppNotificationCommandHandler
        : IRequestHandler<CreateInAppNotificationCommand, InAppNotificationResponse>
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public CreateInAppNotificationCommandHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InAppNotificationResponse> Handle(
            CreateInAppNotificationCommand request,
            CancellationToken cancellationToken
        )
        {
            var notification = new InAppNotification(
                request.Request.UserId,
                request.Request.Type,
                request.Request.Content
            );

            // Apply business rules for creation
            NotificationDeliveryRules.ApplyCreationRules(notification);

            var created = await _repository.CreateAsync(notification);
            return _mapper.Map<InAppNotificationResponse>(created);
        }
    }
}
