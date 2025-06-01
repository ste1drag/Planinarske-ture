using Reviewing.Domain.Common;
using Reviewing.Domain.Enums;
using Reviewing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewing.Domain.Entities
{
    public class Review(int userId, int tourId, string title, string? comment, Difficulty? difficulty, Score? score, int Id, DateTime CreationDate, DateTime UpdateDate) : EntityBase
    (Id, CreationDate, UpdateDate)
    {
        public int UserId { get; } = userId;
        public int TourId { get; } = tourId;
        public string Title { get; set; } = title;
        public string? Comment { get; set; } = comment;
        public Difficulty? Difficulty { get; set; } = difficulty;
        public Score? Score { get; set; } = score;
    }
}
