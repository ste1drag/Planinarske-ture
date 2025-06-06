using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tours.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingWeatherColumnFromMountain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Mountain_MountainId",
                table: "Tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mountain",
                table: "Mountain");

            migrationBuilder.RenameTable(
                name: "Mountain",
                newName: "Mountains");

            migrationBuilder.AddColumn<int>(
                name: "Weather",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mountains",
                table: "Mountains",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Mountains_MountainId",
                table: "Tours",
                column: "MountainId",
                principalTable: "Mountains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Mountains_MountainId",
                table: "Tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mountains",
                table: "Mountains");

            migrationBuilder.DropColumn(
                name: "Weather",
                table: "Tours");

            migrationBuilder.RenameTable(
                name: "Mountains",
                newName: "Mountain");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mountain",
                table: "Mountain",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Mountain_MountainId",
                table: "Tours",
                column: "MountainId",
                principalTable: "Mountain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
