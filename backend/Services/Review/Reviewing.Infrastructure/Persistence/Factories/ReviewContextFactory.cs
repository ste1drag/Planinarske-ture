using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Reviewing.Infrastructure.Persistence.Factories
{
    public class ReviewContextFactory : IDesignTimeDbContextFactory<ReviewContext>
    {
        public ReviewContext CreateDbContext(string[] args)
        {
            const string DB_CONNECTION_STRING = "Host=localhost;Port=6543;Database=reviewing;Username=postgres;Password=postgres";
            var optionsBuilder = new DbContextOptionsBuilder<ReviewContext>();
            optionsBuilder.UseNpgsql(DB_CONNECTION_STRING);
            return new ReviewContext(optionsBuilder.Options);
        }
    }
}