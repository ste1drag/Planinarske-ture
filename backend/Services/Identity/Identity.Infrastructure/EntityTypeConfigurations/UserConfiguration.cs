using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Navigation(u => u.RefreshTokens).AutoInclude();

            // Seed default admin user
            var adminUserId = "550e8400-e29b-41d4-a716-446655440001";
            var hasher = new PasswordHasher<User>();

            var adminUser = new User
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mountainhiking.com",
                NormalizedEmail = "ADMIN@MOUNTAINHIKING.COM",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Administrator",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

            builder.HasData(adminUser);
        }
    }
}
