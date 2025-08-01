using Reviewing.Application.Contracts;
using Reviewing.Domain.Entities;
using Reviewing.Infrastructure.Persistence;

namespace Reviewing.Infrastructure.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>
    {
        public ReviewRepository(ReviewContext context) : base(context)
        {
        }
    }
}
