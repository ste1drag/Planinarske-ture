using Reviewing.Domain.Entities;
using Reviewing.Domain.Enums;
using Reviewing.Domain.ValueObjects;

namespace Reviewing.domain.Factories
{
    public class ReviewFactory
    {
        public ReviewBuilder CreateBuilder()
        {
            return new ReviewBuilder();
        }

        public class ReviewBuilder
        {
            private int _userId = 0;
            private int _tourId = 0;
            private string _title = string.Empty;
            private string? _comment = null;
            private Difficulty? _difficulty = null;
            private Score? _score = null;

            public ReviewBuilder WithUserId(int userId)
            {
                _userId = userId;
                return this;
            }

            public ReviewBuilder WithTourId(int tourId)
            {
                _tourId = tourId;
                return this;
            }

            public ReviewBuilder WithTitle(string title)
            {
                _title = title;
                return this;
            }

            public ReviewBuilder WithComment(string? comment)
            {
                _comment = comment;
                return this;
            }

            public ReviewBuilder WithDifficulty(Difficulty? difficulty)
            {
                _difficulty = difficulty;
                return this;
            }

            public ReviewBuilder WithScore(Score? score)
            {
                _score = score;
                return this;
            }

            public Review Build()
            {
                return new Review(_userId, _tourId, _title, _comment, _difficulty, _score);
            }
        }
    }
}
