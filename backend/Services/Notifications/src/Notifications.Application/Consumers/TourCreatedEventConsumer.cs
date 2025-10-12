using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Events.Events.Tours;
using Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification;
using Notifications.Application.DTOs;
using Notifications.Domain.Enums;

namespace Notifications.Application.Consumers;

public class TourCreatedEventConsumer : IConsumer<TourCreateEvent.TourCreatedEvent>
{
    private readonly IMediator _mediator;
    private readonly ILogger<TourCreatedEventConsumer> _logger;

    public TourCreatedEventConsumer(
        IMediator mediator,
        ILogger<TourCreatedEventConsumer> logger
        )
    {
        _mediator = mediator;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<TourCreateEvent.TourCreatedEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation(
            "Received TourCreatedEvent: TourId={TourId}, Title={Title}",
            message.TourId, message.Name);

        try
        {
            var request = new CreateInAppNotificationRequest //TODO: this should be an interface because its used in multiple places for example TourCreatedEvent and ReviewCreatedEvent
            {
                Id = message.Id.ToString(),
                OccuredOn = message.OccuredOn,
                TourId = message.TourId,
                Type = NotificationTypeEnum.TourCreated,
                Name = message.Name,
                Description = message.Description,
                DateOfTour = message.DateOfTour,
                MountainName = message.MountainName,
                MinNumberOfPeople = message.MinNumberOfPeople,
                MaxNumberOfPeople = message.MaxNumberOfPeople,

            };

            var command = new CreateInAppNotificationCommand(request);
            var response = await _mediator.Send(command);

            _logger.LogInformation(
                "Successfully created notification {NotificationId} for TourId={TourId}",
                response.Id, message.TourId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error processing TourCreatedEvent for TourId={TourId}",
                message.TourId);
            throw;
        }
    }
}