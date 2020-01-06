using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rejoin.Migrations
{
    public partial class unnecessaryTablesDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyReviewReactions");

            migrationBuilder.DropTable(
                name: "CompanyReviewReplies");

            migrationBuilder.DropTable(
                name: "CompanyReviewReports");

            migrationBuilder.DropTable(
                name: "JobReviewReactions");

            migrationBuilder.DropTable(
                name: "JobReviewReplies");

            migrationBuilder.DropTable(
                name: "JobReviewReports");

            migrationBuilder.DropTable(
                name: "CompanyReviews");

            migrationBuilder.DropTable(
                name: "JobReviews");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "WhyYou",
                table: "Applies",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "WhyYou",
                table: "Applies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.CreateTable(
                name: "CompanyReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobReviews_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReviewReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyReviewId = table.Column<int>(type: "int", nullable: false),
                    IsHelpful = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReviewReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReviewReactions_CompanyReviews_CompanyReviewId",
                        column: x => x.CompanyReviewId,
                        principalTable: "CompanyReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyReviewReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReviewReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyReviewId = table.Column<int>(type: "int", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReviewReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReviewReplies_CompanyReviews_CompanyReviewId",
                        column: x => x.CompanyReviewId,
                        principalTable: "CompanyReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyReviewReplies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReviewReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyReviewId = table.Column<int>(type: "int", nullable: false),
                    ReportDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReviewReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReviewReports_CompanyReviews_CompanyReviewId",
                        column: x => x.CompanyReviewId,
                        principalTable: "CompanyReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyReviewReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobReviewReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHelpful = table.Column<bool>(type: "bit", nullable: false),
                    JobReviewId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReviewReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobReviewReactions_JobReviews_JobReviewId",
                        column: x => x.JobReviewId,
                        principalTable: "JobReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobReviewReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobReviewReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobReviewId = table.Column<int>(type: "int", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReviewReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobReviewReplies_JobReviews_JobReviewId",
                        column: x => x.JobReviewId,
                        principalTable: "JobReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobReviewReplies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobReviewReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobReviewId = table.Column<int>(type: "int", nullable: false),
                    ReportDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReviewReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobReviewReports_JobReviews_JobReviewId",
                        column: x => x.JobReviewId,
                        principalTable: "JobReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobReviewReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewReactions_CompanyReviewId",
                table: "CompanyReviewReactions",
                column: "CompanyReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewReactions_UserId",
                table: "CompanyReviewReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewReplies_CompanyReviewId",
                table: "CompanyReviewReplies",
                column: "CompanyReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewReplies_UserId",
                table: "CompanyReviewReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewReports_CompanyReviewId",
                table: "CompanyReviewReports",
                column: "CompanyReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewReports_UserId",
                table: "CompanyReviewReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviews_CompanyId",
                table: "CompanyReviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviews_UserId",
                table: "CompanyReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewReactions_JobReviewId",
                table: "JobReviewReactions",
                column: "JobReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewReactions_UserId",
                table: "JobReviewReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewReplies_JobReviewId",
                table: "JobReviewReplies",
                column: "JobReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewReplies_UserId",
                table: "JobReviewReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewReports_JobReviewId",
                table: "JobReviewReports",
                column: "JobReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewReports_UserId",
                table: "JobReviewReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviews_JobId",
                table: "JobReviews",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviews_UserId",
                table: "JobReviews",
                column: "UserId");
        }
    }
}
