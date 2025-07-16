
using Microsoft.EntityFrameworkCore;
using Reviewing.Domain.Common;
using Reviewing.Domain.Entities;
using Reviewing.Infrastructure.Persistence.EntityConfigurations;

namespace Reviewing.Infrastructure.Persistence
{
    public class ReviewContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; } = null!;

        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        DateTime currentTimestamp = DateTime.UtcNow;
                        entry.Entity.CreatedDate = currentTimestamp;
                        entry.Entity.UpdatedDate = currentTimestamp;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
