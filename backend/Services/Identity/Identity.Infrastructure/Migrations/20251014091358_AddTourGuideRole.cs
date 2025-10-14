using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTourGuideRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "733a223e-a652-4f56-91fe-f44abfbef2dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b491dca-077f-4874-8b97-f34a9df44921");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "733a223e-a652-4f56-91fe-f44abfbef2dc", null, "User", "USER" },
                    { "8b491dca-077f-4874-8b97-f34a9df44921", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
