using Reviewing.Domain.Common;
using Reviewing.Domain.Enums;
using Reviewing.Domain.ValueObjects;

namespace Reviewing.Domain.Entities
{
    public class Review(int userId, int tourId, string title, string? comment, Difficulty? difficulty, Score? score) : EntityBase
    (0, DateTime.Now, DateTime.Now)
    {
        public int UserId { get; } = userId;
        public int TourId { get; } = tourId;
        public string Title { get; set; } = title;
        public string? Comment { get; set; } = comment;
        public Difficulty? Difficulty { get; set; } = difficulty;
        public Score? Score { get; set; } = score;
    }
}
