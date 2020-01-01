using Microsoft.EntityFrameworkCore.Migrations;

namespace Rejoin.Migrations
{
    public partial class BugFixedAtUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Users_UserId",
                table: "Applies");

            migrationBuilder.DropIndex(
                name: "IX_Applies_UserId",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Applies");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Applies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applies_CandidateId",
                table: "Applies",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Candidates_CandidateId",
                table: "Applies",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Candidates_CandidateId",
                table: "Applies");

            migrationBuilder.DropIndex(
                name: "IX_Applies_CandidateId",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Applies");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Applies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applies_UserId",
                table: "Applies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Users_UserId",
                table: "Applies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
