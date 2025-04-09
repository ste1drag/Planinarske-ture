using System.Collections.Generic;
using System.Linq;

namespace Tours.Application.Common.Exceptions
{
    public class ValidationException : BaseException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<(string PropertyName, string ErrorMessage)> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var group in failureGroups)
            {
                Errors.Add(group.Key, group.ToArray());
            }
        }
    }
}