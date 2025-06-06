using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tours.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Mountain_TourId",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Tours",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "MountainId",
                table: "Tours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tours_MountainId",
                table: "Tours",
                column: "MountainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Mountain_MountainId",
                table: "Tours",
                column: "MountainId",
                principalTable: "Mountain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Mountain_MountainId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_MountainId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "MountainId",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tours",
                newName: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Mountain_TourId",
                table: "Tours",
                column: "TourId",
                principalTable: "Mountain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
