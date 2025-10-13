using AutoMapper;
using MediatR;
using Notifications.Application.Business;
using Notifications.Application.DTOs;
using Notifications.Domain.Entities;
using Notifications.Application.Contracts;
using Microsoft.Extensions.Logging;
using MassTransit;
using Shared.Events.Gateway;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification;

public class CreateInAppNotificationCommandHandler
    : IRequestHandler<CreateInAppNotificationCommand, InAppNotificationResponse>
{
    private readonly IInAppNotificationRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateInAppNotificationCommandHandler> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateInAppNotificationCommandHandler(
        IInAppNotificationRepository repository,
        IMapper mapper,
        ILogger<CreateInAppNotificationCommandHandler> logger,
        IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<InAppNotificationResponse> Handle(
        CreateInAppNotificationCommand request,
        CancellationToken cancellationToken)
    {
        // Use AutoMapper to create the entity from the request
        var notification = _mapper.Map<InAppNotification>(request.Request);
        _logger.LogInformation("Recieving in-app notification from RabbitMQ: {@Notification}", notification);

        // Apply business rules for creation
        NotificationDeliveryRules.ApplyCreationRules(notification);

        var created = await _repository.AddAsync(notification);

        _logger.LogInformation("In-app notification created: {@Notification}", created);

        try
        {
            var notificationEvent = new InAppNotificationCreatedTourEvent
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Title = created.Title,
                DescriptionOfTour = created.DescriptionOfTour,
                Content = created.Content
            };

            await _publishEndpoint.Publish(notificationEvent, cancellationToken);
            _logger.LogInformation("Published notification event to RabbitMQ: {@Event}", notificationEvent);


            NotificationDeliveryRules.ApplyDeliveryRules(created, true);
            _logger.LogInformation("In-app notification sent: {@Notification}", created);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to publish notification event for {NotificationId}", created.Id);

            // Mark as failed using your existing rule
            NotificationDeliveryRules.ApplyDeliveryRules(created, false);
            _logger.LogWarning("In-app notification marked as failed: {@Notification}", created);
        }
        finally
        {
            // Update the notification status (sent or failed)
            await _repository.UpdateAsync(created);
        }

        return _mapper.Map<InAppNotificationResponse>(created);
    }
}