using Microsoft.EntityFrameworkCore;
using Reviewing.Domain.Entities;
using Reviewing.Infrastructure.Persistence;

namespace Reviewing.Infrastructure.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>
    {
        public ReviewRepository(ReviewContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetByTourId(Guid tourId)
        {
            return await _context.Set<Review>()
                .Where(r => r.TourId == tourId)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
        }
    }
}
