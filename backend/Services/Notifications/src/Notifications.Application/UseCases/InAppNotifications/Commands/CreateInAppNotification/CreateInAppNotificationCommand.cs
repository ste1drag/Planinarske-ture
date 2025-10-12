using MediatR;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification;

public record CreateInAppNotificationCommand(CreateInAppNotificationRequest Request)
    : IRequest<InAppNotificationResponse>;