using MassTransit;
using MediatR;
// using Microsoft.Extensions.Logging;
using Shared.Events.Events.Tours;
using Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification;
using Notifications.Application.DTOs;
using Notifications.Domain.Enums;

namespace Notifications.Application.Consumers;

public class TourCreatedEventConsumer : IConsumer<TourCreateEvent.TourCreatedEvent>
{
    private readonly IMediator _mediator;
    // private readonly ILogger<TourCreatedEventConsumer> _logger;

    public TourCreatedEventConsumer(
        IMediator mediator
        // ILogger<TourCreatedEventConsumer> logger
        )
    {
        _mediator = mediator;
        // _logger = logger;
    }

    public async Task Consume(ConsumeContext<TourCreateEvent.TourCreatedEvent> context)
    {
        var message = context.Message;

        // _logger.LogInformation(
        //     "Received TourCreatedEvent: TourId={TourId}, Title={Title}",
        //     message.TourId, message.Title);

        try
        {
            var request = new CreateInAppNotificationRequest
            {
                UserId = message.CreateByUserId,
                Type = NotificationTypeEnum.TourCreated,
                Title = "New Tour Created",
                Message = $"Tour '{message.Title}' has been created successfully.",
                Content = $"A new tour '{message.Title}' has been created.",
                RelatedEntityId = message.TourId,
                RelatedEntityType = "Tour"
            };

            var command = new CreateInAppNotificationCommand(request);
            var response = await _mediator.Send(command);

            // _logger.LogInformation(
            //     "Successfully created notification {NotificationId} for TourId={TourId}",
            //     response.Id, message.TourId);
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex,
            //     "Error processing TourCreatedEvent for TourId={TourId}",
            //     message.TourId);
            throw;
        }
    }
}