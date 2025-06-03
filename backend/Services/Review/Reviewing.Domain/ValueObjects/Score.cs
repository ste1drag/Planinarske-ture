using Reviewing.Domain.Common;

namespace Reviewing.Domain.ValueObjects
{
    public class Score : ValueObjectBase
    {
        public int Value { get; }
        private const int UPPER_BOUND = 5;
        private const int LOWER_BOUND = 1;
        private int? score;

        public Score(int value)
        {
            if (value < LOWER_BOUND || value > UPPER_BOUND)
            {
                throw new ArgumentException($"Score must be between {LOWER_BOUND} and {UPPER_BOUND}");
            }
            Value = value;
        }

        public Score(int? score)
        {
            this.score = score;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
