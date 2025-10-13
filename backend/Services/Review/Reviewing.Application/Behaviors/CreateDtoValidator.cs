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

            // Include base validation rules for Comment, Difficulty, and Score
            RuleFor(x => x.Comment)
                .MaximumLength(ReviewValidationConstants.MaxCommentLength)
                .When(x => !string.IsNullOrEmpty(x.Comment))
                .WithMessage($"Comment cannot exceed {ReviewValidationConstants.MaxCommentLength} characters.");

            RuleFor(x => x.Difficulty)
                .InclusiveBetween(ReviewValidationConstants.MinDifficulty, ReviewValidationConstants.MaxDifficulty)
                .When(x => x.Difficulty.HasValue)
                .WithMessage($"Difficulty must be between {ReviewValidationConstants.MinDifficulty} and {ReviewValidationConstants.MaxDifficulty}.");

            RuleFor(x => x.Score)
                .InclusiveBetween(ReviewValidationConstants.MinScore, ReviewValidationConstants.MaxScore)
                .When(x => x.Score.HasValue)
                .WithMessage($"Score must be between {ReviewValidationConstants.MinScore} and {ReviewValidationConstants.MaxScore}.");
        }

        private async Task<bool> IsTourPast(Guid tourId)
        {
            var tour = await _tourService.GetTourByIdAsync(tourId);

            if (tour == null)
            {
                // Tour not found - this will be handled as a validation failure
                return false;
            }

            // Ensure the date is treated as UTC if it's unspecified
            var tourDate = tour.Date.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(tour.Date, DateTimeKind.Utc)
                : tour.Date.ToUniversalTime();

            // Tour date must be in the past (using UTC for consistency)
            return tourDate < DateTime.UtcNow;
        }
    }
}
