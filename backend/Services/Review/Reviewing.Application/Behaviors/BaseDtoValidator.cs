using FluentValidation;
using Reviewing.Application.DTOs;

namespace Reviewing.Application.Behaviors
{
    public class BaseDtoValidator : AbstractValidator<CreateReviewDto>
    {
        public BaseDtoValidator()
        {
            RuleFor(x => x.Comment)
                .MaximumLength(ReviewValidationConstants.MaxCommentLength)
                .WithMessage($"Comment cannot exceed {ReviewValidationConstants.MaxCommentLength} characters.");

            RuleFor(x => x.Difficulty)
                .InclusiveBetween(ReviewValidationConstants.MinDifficulty, ReviewValidationConstants.MaxDifficulty)
                .WithMessage($"Difficulty must be between {ReviewValidationConstants.MinDifficulty} and {ReviewValidationConstants.MaxDifficulty}.");

            RuleFor(x => x.Score)
                .InclusiveBetween(ReviewValidationConstants.MinScore, ReviewValidationConstants.MaxScore)
                .WithMessage($"Score must be between {ReviewValidationConstants.MinScore} and {ReviewValidationConstants.MaxScore}.");
        }
    }
}
