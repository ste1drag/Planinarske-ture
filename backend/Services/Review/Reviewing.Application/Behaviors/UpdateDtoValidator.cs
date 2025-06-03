using FluentValidation;
using Reviewing.Application.DTOs;

namespace Reviewing.Application.Behaviors
{
    public class UpdateDtoValidator : AbstractValidator<UpdateReviewDto>
    {
        public UpdateDtoValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Review ID is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Review ID must be greater than 0.");

            RuleFor(x => x.Title)
                .MaximumLength(ReviewValidationConstants.MaxTitleLength).WithMessage($"Title cannot exceed {ReviewValidationConstants.MaxTitleLength} characters.");
        }
    }
}
