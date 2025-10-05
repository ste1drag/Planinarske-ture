using FluentValidation;
using Notifications.Domain.Enums;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.UpdateInAppNotification
{
    public class UpdateInAppNotificationCommandValidator
        : AbstractValidator<UpdateInAppNotificationCommand>
    {
        public UpdateInAppNotificationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Request).NotNull().WithMessage("Request cannot be null");

            RuleFor(x => x.Request.Type)
                .IsInEnum()
                .WithMessage("Type must be a valid notification type");

            RuleFor(x => x.Request.Content)
                .NotEmpty()
                .WithMessage("Content is required")
                .MaximumLength(1000)
                .WithMessage("Content cannot exceed 1000 characters");

            RuleFor(x => x.Request.Status)
                .IsInEnum()
                .WithMessage("Status must be a valid delivery status");
        }
    }
}
