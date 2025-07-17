using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Identity.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Identity.API"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("IdentityDB");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'IdentityDB' not found in configuration.");
            }

            optionsBuilder.UseSqlServer(connectionString,
                sql => sql.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.MigrationAttributeMissingWarning));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}