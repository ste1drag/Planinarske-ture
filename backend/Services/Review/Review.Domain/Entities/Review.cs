using Review.Domain.Common;
using Review.Domain.Enums;
using Review.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Domain.Entities
{
    public class Review(int userId, int tourId, string title, string? comment, Difficulty difficulty, Score score) : EntityBase
    {
        public int UserId { get; } = userId;
        public int TourId { get; } = tourId;
        public required string Title { get; set; } = title;
        public string? Comment { get; set; } = comment;
        public Difficulty Difficulty { get; set; } = difficulty;
        public required Score Score { get; set; } = score;
    }
}
