using FluentValidation;


namespace Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification
{
    public class CreateInAppNotificationCommandValidator
        : AbstractValidator<CreateInAppNotificationCommand>
    {
        public CreateInAppNotificationCommandValidator()
        {
            RuleFor(x => x.Request).NotNull().WithMessage("Request cannot be null");

            RuleFor(x => x.Request.TourId)
                .NotEmpty()
                .WithMessage("TourId is required")
                .MaximumLength(100)
                .WithMessage("TourId cannot exceed 100 characters");

            RuleFor(x => x.Request.Type)
                .IsInEnum()
                .WithMessage("Type must be a valid notification type");

        }
    }
}
