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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public const string AdminRoleId = "660e8400-e29b-41d4-a716-446655440002";
        public const string UserRoleId = "660e8400-e29b-41d4-a716-446655440003";
        public const string TourGuideRoleId = "660e8400-e29b-41d4-a716-446655440004";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper(),
                    ConcurrencyStamp = AdminRoleId
                },
                new IdentityRole
                {
                    Id = UserRoleId,
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper(),
                    ConcurrencyStamp = UserRoleId
                },
                new IdentityRole
                {
                    Id = TourGuideRoleId,
                    Name = Roles.TourGuide,
                    NormalizedName = Roles.TourGuide.ToUpper(),
                    ConcurrencyStamp = TourGuideRoleId
                }
            );
        }
    }
}
