using System;
using Reviewing.Domain.ValueObjects;
using Xunit;

namespace Review.Domain.Tests.Tests
{
    public class ValueObjects
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void Score_ValidValue_CreatesScore(int validValue)
        {
            var score = new Score(validValue);
            Assert.Equal(validValue, score.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        [InlineData(-1)]
        public void Score_InvalidValue_ThrowsArgumentException(int invalidValue)
        {
            Assert.Throws<ArgumentException>(() => new Score(invalidValue));
        }

        [Fact]
        public void Score_Equality_WorksForSameValue()
        {
            var score1 = new Score(4);
            var score2 = new Score(4);
            Assert.Equal(score1, score2);
            Assert.Equal(score1.GetHashCode(), score2.GetHashCode());
        }

        [Fact]
        public void Score_Equality_FailsForDifferentValue()
        {
            var score1 = new Score(2);
            var score2 = new Score(3);
            Assert.NotEqual(score1, score2);
        }
    }
}
