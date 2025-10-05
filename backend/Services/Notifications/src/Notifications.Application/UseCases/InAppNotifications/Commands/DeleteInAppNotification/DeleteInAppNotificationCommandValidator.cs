using FluentValidation;

namespace Notifications.Application.UseCases.InAppNotifications.Commands.DeleteInAppNotification
{
    public class DeleteInAppNotificationCommandValidator
        : AbstractValidator<DeleteInAppNotificationCommand>
    {
        public DeleteInAppNotificationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required")
                .Must(BeValidId)
                .WithMessage("Id must be a valid format");
        }

        private bool BeValidId(string id)
        {
            // Basic validation for MongoDB ObjectId format (24 characters, hexadecimal)
            return !string.IsNullOrEmpty(id)
                && id.Length == 24
                && id.All(c => "0123456789abcdefABCDEF".Contains(c));
        }
    }
}
