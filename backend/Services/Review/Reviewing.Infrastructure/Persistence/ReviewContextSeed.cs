using Microsoft.Extensions.Logging;
using Reviewing.Domain.Entities;
using Reviewing.Domain.ValueObjects;
using Reviewing.Domain.Enums;

namespace Reviewing.Infrastructure.Persistence
{
    public class ReviewContextSeed
    {
        public static async Task SeedAsync(ReviewContext reviewContext, ILogger<ReviewContextSeed> logger)
        {
            reviewContext.Reviews.AddRange(GetPreconfiguredReviews());
            await reviewContext.SaveChangesAsync();
            logger.LogInformation("Seeding database associated with context {DbContextName}", nameof(reviewContext));
        }

        private static IEnumerable<Review> GetPreconfiguredReviews()
        {
            // Tour IDs from Tours.Infrastructure.SeedData
            var pastTour1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"); // Kopaonik Summit Adventure
            var pastTour2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"); // Zlatibor Nature Trail
            var pastTour3Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"); // Stara Planina Waterfalls Tour
            var pastTour4Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"); // Fruska Gora Monastery Circuit

            return new List<Review>
            {
                // Reviews for Kopaonik Summit Adventure (Past Tour 1)
                new Review(1, pastTour1Id, "Breathtaking Summit Views", "The climb to Kopaonik's peak was challenging but absolutely worth it! The alpine meadows were stunning and our guide was very knowledgeable.", Difficulty.HARD, new Score(5)),
                new Review(2, pastTour1Id, "Great Challenge", "Loved the difficulty level. Perfect for experienced hikers looking for a good workout with rewarding views.", Difficulty.HARD, new Score(4)),
                new Review(3, pastTour1Id, "Tough but Beautiful", "The trail was steep in places but the pristine nature made up for the difficulty. Would recommend proper hiking boots!", Difficulty.VERY_HARD, new Score(4)),

                // Reviews for Zlatibor Nature Trail (Past Tour 2)
                new Review(4, pastTour2Id, "Perfect Family Tour", "Easy walking tour through beautiful meadows. My kids loved it and so did my elderly parents. Very well organized!", Difficulty.EASY, new Score(5)),
                new Review(5, pastTour2Id, "Relaxing Nature Walk", "Great for beginners. The weather was a bit cloudy but it didn't dampen our spirits. Beautiful forests and open spaces.", Difficulty.VERY_EASY, new Score(5)),
                new Review(6, pastTour2Id, "Nice but Expected More", "It was pleasant but felt a bit too easy for my taste. Would be perfect for those new to hiking though.", Difficulty.EASY, new Score(3)),

                // Reviews for Stara Planina Waterfalls Tour (Past Tour 3)
                new Review(7, pastTour3Id, "Spectacular Waterfalls!", "The waterfalls were absolutely magnificent! Even though it rained, it actually made the waterfalls more impressive. Great photo opportunities.", Difficulty.MEDIUM, new Score(5)),
                new Review(8, pastTour3Id, "Amazing Gorges", "The gorges of Stara Planina are breathtaking. Moderate difficulty, good for intermediate hikers. The rain made trails a bit slippery though.", Difficulty.MEDIUM, new Score(4)),
                new Review(9, pastTour3Id, "Nature at Its Best", "Beautiful waterfalls and diverse landscapes. The guide knew all the best spots for photos. Highly recommend!", Difficulty.MEDIUM, new Score(5)),

                // Reviews for Fruska Gora Monastery Circuit (Past Tour 4)
                new Review(10, pastTour4Id, "Cultural and Natural Beauty", "Loved visiting the historic monasteries while enjoying nature. Perfect blend of culture and hiking. Very easy terrain.", Difficulty.EASY, new Score(5)),
                new Review(11, pastTour4Id, "Educational Tour", "Learned so much about Serbian history and Orthodox monasteries. The hiking was easy which allowed us to focus on the cultural aspects.", Difficulty.VERY_EASY, new Score(4)),
                new Review(12, pastTour4Id, "Great for All Ages", "My whole family enjoyed this tour. The monasteries are beautiful and the walking was easy enough for everyone. Sunny weather made it perfect!", Difficulty.EASY, new Score(5))
            };
        }

    }
}
