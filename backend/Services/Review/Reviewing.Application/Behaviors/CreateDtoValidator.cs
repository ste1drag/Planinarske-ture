using FluentValidation;
using Reviewing.Application.DTOs;
using Reviewing.Application.Services;

namespace Reviewing.Application.Behaviors
{
    public class CreateDtoValidator : AbstractValidator<CreateReviewDto>
    {
        private readonly ITourService _tourService;

        public CreateDtoValidator(ITourService tourService)
        {
            _tourService = tourService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(ReviewValidationConstants.MaxTitleLength)
                .WithMessage($"Title cannot exceed {ReviewValidationConstants.MaxTitleLength} characters.");

            RuleFor(x => x.TourId)
                .MustAsync(async (tourId, cancellation) => await IsTourPast(tourId))
                .WithMessage("Reviews can only be created for tours that have already occurred.");
        }

        private async Task<bool> IsTourPast(Guid tourId)
        {
            var tour = await _tourService.GetTourByIdAsync(tourId);

            if (tour == null)
            {
                // Tour not found - this will be handled as a validation failure
                return false;
            }

            // Tour date must be in the past (using UTC for consistency)
            return tour.Date < DateTime.UtcNow;
        }
    }
}
