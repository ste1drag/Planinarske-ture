using FluentValidation;
using Notifications.Domain.Enums;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification
{
    public class CreateInAppNotificationCommandValidator
        : AbstractValidator<CreateInAppNotificationCommand>
    {
        public CreateInAppNotificationCommandValidator()
        {
            RuleFor(x => x.Request).NotNull().WithMessage("Request cannot be null");

            RuleFor(x => x.Request.UserId)
                .NotEmpty()
                .WithMessage("UserId is required")
                .MaximumLength(100)
                .WithMessage("UserId cannot exceed 100 characters");

            RuleFor(x => x.Request.Type)
                .IsInEnum()
                .WithMessage("Type must be a valid notification type");

            RuleFor(x => x.Request.Content)
                .NotEmpty()
                .WithMessage("Content is required")
                .MaximumLength(1000)
                .WithMessage("Content cannot exceed 1000 characters");
        }
    }
}
