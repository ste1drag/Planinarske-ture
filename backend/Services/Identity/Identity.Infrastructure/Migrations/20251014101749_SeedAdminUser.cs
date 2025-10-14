using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fdf221c-6a90-4266-a4d0-4f6442c8bff6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "803e7e5d-afa0-4f97-ac83-e8e17819cffa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b2f74a-83ae-4088-93c5-33f4a0fd8fef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "660e8400-e29b-41d4-a716-446655440002", "660e8400-e29b-41d4-a716-446655440002", "Administrator", "ADMINISTRATOR" },
                    { "660e8400-e29b-41d4-a716-446655440003", "660e8400-e29b-41d4-a716-446655440003", "User", "USER" },
                    { "660e8400-e29b-41d4-a716-446655440004", "660e8400-e29b-41d4-a716-446655440004", "TourGuide", "TOURGUIDE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "550e8400-e29b-41d4-a716-446655440001", 0, "4de519e8-9e50-46dc-9baa-ef692602d4ea", "admin@mountainhiking.com", true, "System", "Administrator", false, null, "ADMIN@MOUNTAINHIKING.COM", "ADMIN", "AQAAAAIAAYagAAAAEFw+Z6Q4B9QFnq2m1e0+p1H68QFsuO6e1ZGaMNSmHHM5SgSPZ9T72VD8kIS2DLNn2A==", null, false, "7b5d9e64-8b0a-4378-982b-8945162a22c2", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "660e8400-e29b-41d4-a716-446655440002", "550e8400-e29b-41d4-a716-446655440001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "660e8400-e29b-41d4-a716-446655440003");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "660e8400-e29b-41d4-a716-446655440004");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "660e8400-e29b-41d4-a716-446655440002", "550e8400-e29b-41d4-a716-446655440001" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "660e8400-e29b-41d4-a716-446655440002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "550e8400-e29b-41d4-a716-446655440001");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fdf221c-6a90-4266-a4d0-4f6442c8bff6", null, "User", "USER" },
                    { "803e7e5d-afa0-4f97-ac83-e8e17819cffa", null, "Administrator", "ADMINISTRATOR" },
                    { "a3b2f74a-83ae-4088-93c5-33f4a0fd8fef", null, "TourGuide", "TOURGUIDE" }
                });
        }
    }
}
