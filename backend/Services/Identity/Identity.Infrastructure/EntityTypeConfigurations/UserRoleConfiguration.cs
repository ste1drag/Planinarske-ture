using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.EntityTypeConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // Seed admin user role assignment
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "550e8400-e29b-41d4-a716-446655440001", // Admin user ID from UserConfiguration
                    RoleId = RoleConfiguration.AdminRoleId
                }
            );
        }
    }
}
