using FluentValidation.Results;

namespace Reviewing.Application.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationFailedException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation failures have occurred.")
        {
            Errors = failures
                .GroupBy(f => f.PropertyName, f => f.ErrorMessage)
                .ToDictionary(
                    failureGroup => failureGroup.Key,
                    failureGroup => failureGroup.ToArray()
                );
        }
    }
}