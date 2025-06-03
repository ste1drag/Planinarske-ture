using FluentValidation;
using Reviewing.Application.DTOs;

namespace Reviewing.Application.Behaviors
{
    public class CreateDtoValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(ReviewValidationConstants.MaxTitleLength)
                .WithMessage($"Title cannot exceed {ReviewValidationConstants.MaxTitleLength} characters.");
        }
    }
}
