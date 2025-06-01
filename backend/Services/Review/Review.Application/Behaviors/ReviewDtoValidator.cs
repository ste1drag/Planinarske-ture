using FluentValidation;
using Reviewing.Application.DTOs;

namespace Reviewing.Application.Behaviors
{
    public class ReviewDtoValidator : AbstractValidator<ReviewDto>
    {
        public ReviewDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThanOrEqualTo(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.TourId)
                .GreaterThanOrEqualTo(0).WithMessage("TourId must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(ReviewValidationConstants.MaxTitleLength).WithMessage($"Title cannot exceed {ReviewValidationConstants.MaxTitleLength} characters.");

            RuleFor(x => x.Comment)
                .MaximumLength(ReviewValidationConstants.MaxCommentLength).WithMessage($"Comment cannot exceed {ReviewValidationConstants.MaxCommentLength} characters.");

            RuleFor(x => x.Difficulty)
                .InclusiveBetween(ReviewValidationConstants.MinDifficulty, ReviewValidationConstants.MaxDifficulty)
                .WithMessage($"Difficulty must be between {ReviewValidationConstants.MinDifficulty} and {ReviewValidationConstants.MaxDifficulty}.");

            RuleFor(x => x.Score)
                .InclusiveBetween(ReviewValidationConstants.MinScore, ReviewValidationConstants.MaxScore)
                .WithMessage($"Score must be between {ReviewValidationConstants.MinScore} and {ReviewValidationConstants.MaxScore}.");
        }
    }
}
