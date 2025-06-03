using Microsoft.Extensions.Logging;
using Reviewing.Domain.Entities;
using Reviewing.Domain.ValueObjects;
using Reviewing.Domain.Enums;

namespace Reviewing.Infrastructure.Persistence
{
    class ReviewContextSeed
    {
        public static async Task SeedAsync(ReviewContext reviewContext, ILogger<ReviewContextSeed> logger)
        {
            reviewContext.Reviews.AddRange(GetPreconfiguredReviews());
            await reviewContext.SaveChangesAsync();
            logger.LogInformation("Seeding database associated with context {DbContextName}", nameof(reviewContext));
        }

        private static IEnumerable<Review> GetPreconfiguredReviews()
        {
            return new List<Review>
            {
                new Review(1, 1, "Great Tour", "I had an amazing time!", Difficulty.EASY, new Score(5)),
                new Review(2, 2, "Not bad", "It was okay, could be better.", Difficulty.MEDIUM, new Score(3)),
                new Review(3, 1, "Wonderful Experience", "Loved every moment!", Difficulty.VERY_EASY, new Score(5)),
                new Review(4, 3, "Challenging but Fun", "A bit tough, but rewarding.", Difficulty.HARD, new Score(4)),
                new Review(5, 4, "Too Difficult", "I struggled a lot.", Difficulty.VERY_HARD, new Score(2)),
                new Review(6, 2, "Average", "Nothing special.", Difficulty.MEDIUM, new Score(3)),
                new Review(7, 5, "Perfect for Beginners", "Easy and enjoyable.", Difficulty.EASY, new Score(5)),
                new Review(8, 3, "Not for Me", "Didn't enjoy it much.", Difficulty.HARD, new Score(2)),
                new Review(9, 4, "Spectacular Views", "The scenery was breathtaking.", Difficulty.MEDIUM, new Score(4)),
                new Review(10, 5, "Well Organized", "Everything went smoothly.", Difficulty.EASY, new Score(5)),
                new Review(11, 1, "Could be Better", "Expected more from the tour.", Difficulty.MEDIUM, new Score(3)),
                new Review(12, 2, "Loved It", "Would do it again!", Difficulty.EASY, new Score(5))
            };
        }

    }
}
