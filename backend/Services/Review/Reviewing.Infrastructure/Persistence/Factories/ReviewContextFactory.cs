using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Reviewing.Infrastructure.Persistence
{
    public class ReviewContextFactory : IDesignTimeDbContextFactory<ReviewContext>
    {
        public ReviewContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReviewContext>();
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                       ?? throw new InvalidOperationException("Connection string not found in environment variable 'DB_CONNECTION_STRING'.");
            optionsBuilder.UseNpgsql(connectionString);
            return new ReviewContext(optionsBuilder.Options);
        }
    }
}