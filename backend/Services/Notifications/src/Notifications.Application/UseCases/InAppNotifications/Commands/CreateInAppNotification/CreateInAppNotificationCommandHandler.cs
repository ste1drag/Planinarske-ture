using AutoMapper;
using MediatR;
using Notifications.Application.Business;
using Notifications.Application.DTOs;
using Notifications.Domain.Entities;
using Notifications.Application.Contracts;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification;

public class CreateInAppNotificationCommandHandler
    : IRequestHandler<CreateInAppNotificationCommand, InAppNotificationResponse>
{
    private readonly IInAppNotificationRepository _repository;
    private readonly IMapper _mapper;

    public CreateInAppNotificationCommandHandler(
        IInAppNotificationRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<InAppNotificationResponse> Handle(
        CreateInAppNotificationCommand request,
        CancellationToken cancellationToken)
    {
        // Use AutoMapper to create the entity from the request
        var notification = _mapper.Map<InAppNotification>(request.Request);

        // Apply business rules for creation
        NotificationDeliveryRules.ApplyCreationRules(notification);

        var created = await _repository.AddAsync(notification);

        //->Rabbit MQ -> GW consumes -> SignalR notify user
        return _mapper.Map<InAppNotificationResponse>(created);
    }
}