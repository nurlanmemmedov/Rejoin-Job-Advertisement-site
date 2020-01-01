using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rejoin.Migrations
{
    public partial class isActiveAddedToJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Jobs",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedAt",
                table: "Applies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AppliedAt",
                table: "Applies");
        }
    }
}
