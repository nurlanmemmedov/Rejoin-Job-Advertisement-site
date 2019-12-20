using Microsoft.EntityFrameworkCore.Migrations;

namespace Rejoin.Migrations
{
    public partial class CompanyAndJobTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Users_UserId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_UserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReview_Company_CompanyId",
                table: "CompanyReview");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReview_Users_UserId",
                table: "CompanyReview");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReaction_CompanyReview_CompanyReviewId",
                table: "CompanyReviewReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReaction_Users_UserId",
                table: "CompanyReviewReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReply_CompanyReview_CompanyReviewId",
                table: "CompanyReviewReply");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReply_Users_UserId",
                table: "CompanyReviewReply");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReport_CompanyReview_CompanyReviewId",
                table: "CompanyReviewReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReport_Users_UserId",
                table: "CompanyReviewReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySocialLink_Company_CompanyId",
                table: "CompanySocialLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Candidate_CandidateId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Candidate_CandidateId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Category_CategoryId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReview_Job_JobId",
                table: "JobReview");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReview_Users_UserId",
                table: "JobReview");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReaction_JobReview_JobReviewId",
                table: "JobReviewReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReaction_Users_UserId",
                table: "JobReviewReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReply_JobReview_JobReviewId",
                table: "JobReviewReply");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReply_Users_UserId",
                table: "JobReviewReply");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReport_JobReview_JobReviewId",
                table: "JobReviewReport");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReport_Users_UserId",
                table: "JobReviewReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviewReport",
                table: "JobReviewReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviewReply",
                table: "JobReviewReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviewReaction",
                table: "JobReviewReaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReview",
                table: "JobReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanySocialLink",
                table: "CompanySocialLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviewReport",
                table: "CompanyReviewReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviewReply",
                table: "CompanyReviewReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviewReaction",
                table: "CompanyReviewReaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReview",
                table: "CompanyReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.RenameTable(
                name: "JobReviewReport",
                newName: "JobReviewReports");

            migrationBuilder.RenameTable(
                name: "JobReviewReply",
                newName: "JobReviewReplies");

            migrationBuilder.RenameTable(
                name: "JobReviewReaction",
                newName: "JobReviewReactions");

            migrationBuilder.RenameTable(
                name: "JobReview",
                newName: "JobReviews");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Experience",
                newName: "Experiences");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "CompanySocialLink",
                newName: "CompanySocialLinks");

            migrationBuilder.RenameTable(
                name: "CompanyReviewReport",
                newName: "CompanyReviewReports");

            migrationBuilder.RenameTable(
                name: "CompanyReviewReply",
                newName: "CompanyReviewReplies");

            migrationBuilder.RenameTable(
                name: "CompanyReviewReaction",
                newName: "CompanyReviewReactions");

            migrationBuilder.RenameTable(
                name: "CompanyReview",
                newName: "CompanyReviews");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReport_UserId",
                table: "JobReviewReports",
                newName: "IX_JobReviewReports_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReport_JobReviewId",
                table: "JobReviewReports",
                newName: "IX_JobReviewReports_JobReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReply_UserId",
                table: "JobReviewReplies",
                newName: "IX_JobReviewReplies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReply_JobReviewId",
                table: "JobReviewReplies",
                newName: "IX_JobReviewReplies_JobReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReaction_UserId",
                table: "JobReviewReactions",
                newName: "IX_JobReviewReactions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReaction_JobReviewId",
                table: "JobReviewReactions",
                newName: "IX_JobReviewReactions_JobReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReview_UserId",
                table: "JobReviews",
                newName: "IX_JobReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReview_JobId",
                table: "JobReviews",
                newName: "IX_JobReviews_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_CompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_CategoryId",
                table: "Jobs",
                newName: "IX_Jobs_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Experience_CandidateId",
                table: "Experiences",
                newName: "IX_Experiences_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Education_CandidateId",
                table: "Educations",
                newName: "IX_Educations_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanySocialLink_CompanyId",
                table: "CompanySocialLinks",
                newName: "IX_CompanySocialLinks_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReport_UserId",
                table: "CompanyReviewReports",
                newName: "IX_CompanyReviewReports_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReport_CompanyReviewId",
                table: "CompanyReviewReports",
                newName: "IX_CompanyReviewReports_CompanyReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReply_UserId",
                table: "CompanyReviewReplies",
                newName: "IX_CompanyReviewReplies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReply_CompanyReviewId",
                table: "CompanyReviewReplies",
                newName: "IX_CompanyReviewReplies_CompanyReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReaction_UserId",
                table: "CompanyReviewReactions",
                newName: "IX_CompanyReviewReactions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReaction_CompanyReviewId",
                table: "CompanyReviewReactions",
                newName: "IX_CompanyReviewReactions_CompanyReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReview_UserId",
                table: "CompanyReviews",
                newName: "IX_CompanyReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReview_CompanyId",
                table: "CompanyReviews",
                newName: "IX_CompanyReviews_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_UserId",
                table: "Companies",
                newName: "IX_Companies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_UserId",
                table: "Candidates",
                newName: "IX_Candidates_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviewReports",
                table: "JobReviewReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviewReplies",
                table: "JobReviewReplies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviewReactions",
                table: "JobReviewReactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviews",
                table: "JobReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanySocialLinks",
                table: "CompanySocialLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviewReports",
                table: "CompanyReviewReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviewReplies",
                table: "CompanyReviewReplies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviewReactions",
                table: "CompanyReviewReactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviews",
                table: "CompanyReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Users_UserId",
                table: "Candidates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReactions_CompanyReviews_CompanyReviewId",
                table: "CompanyReviewReactions",
                column: "CompanyReviewId",
                principalTable: "CompanyReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReactions_Users_UserId",
                table: "CompanyReviewReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReplies_CompanyReviews_CompanyReviewId",
                table: "CompanyReviewReplies",
                column: "CompanyReviewId",
                principalTable: "CompanyReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReplies_Users_UserId",
                table: "CompanyReviewReplies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReports_CompanyReviews_CompanyReviewId",
                table: "CompanyReviewReports",
                column: "CompanyReviewId",
                principalTable: "CompanyReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReports_Users_UserId",
                table: "CompanyReviewReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviews_Companies_CompanyId",
                table: "CompanyReviews",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviews_Users_UserId",
                table: "CompanyReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySocialLinks_Companies_CompanyId",
                table: "CompanySocialLinks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Candidates_CandidateId",
                table: "Educations",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Candidates_CandidateId",
                table: "Experiences",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReactions_JobReviews_JobReviewId",
                table: "JobReviewReactions",
                column: "JobReviewId",
                principalTable: "JobReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReactions_Users_UserId",
                table: "JobReviewReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReplies_JobReviews_JobReviewId",
                table: "JobReviewReplies",
                column: "JobReviewId",
                principalTable: "JobReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReplies_Users_UserId",
                table: "JobReviewReplies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReports_JobReviews_JobReviewId",
                table: "JobReviewReports",
                column: "JobReviewId",
                principalTable: "JobReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReports_Users_UserId",
                table: "JobReviewReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviews_Jobs_JobId",
                table: "JobReviews",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviews_Users_UserId",
                table: "JobReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Users_UserId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReactions_CompanyReviews_CompanyReviewId",
                table: "CompanyReviewReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReactions_Users_UserId",
                table: "CompanyReviewReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReplies_CompanyReviews_CompanyReviewId",
                table: "CompanyReviewReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReplies_Users_UserId",
                table: "CompanyReviewReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReports_CompanyReviews_CompanyReviewId",
                table: "CompanyReviewReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviewReports_Users_UserId",
                table: "CompanyReviewReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviews_Companies_CompanyId",
                table: "CompanyReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyReviews_Users_UserId",
                table: "CompanyReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySocialLinks_Companies_CompanyId",
                table: "CompanySocialLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Candidates_CandidateId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Candidates_CandidateId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReactions_JobReviews_JobReviewId",
                table: "JobReviewReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReactions_Users_UserId",
                table: "JobReviewReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReplies_JobReviews_JobReviewId",
                table: "JobReviewReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReplies_Users_UserId",
                table: "JobReviewReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReports_JobReviews_JobReviewId",
                table: "JobReviewReports");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviewReports_Users_UserId",
                table: "JobReviewReports");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviews_Jobs_JobId",
                table: "JobReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_JobReviews_Users_UserId",
                table: "JobReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviews",
                table: "JobReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviewReports",
                table: "JobReviewReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviewReplies",
                table: "JobReviewReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobReviewReactions",
                table: "JobReviewReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanySocialLinks",
                table: "CompanySocialLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviews",
                table: "CompanyReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviewReports",
                table: "CompanyReviewReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviewReplies",
                table: "CompanyReviewReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReviewReactions",
                table: "CompanyReviewReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "JobReviews",
                newName: "JobReview");

            migrationBuilder.RenameTable(
                name: "JobReviewReports",
                newName: "JobReviewReport");

            migrationBuilder.RenameTable(
                name: "JobReviewReplies",
                newName: "JobReviewReply");

            migrationBuilder.RenameTable(
                name: "JobReviewReactions",
                newName: "JobReviewReaction");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newName: "Experience");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameTable(
                name: "CompanySocialLinks",
                newName: "CompanySocialLink");

            migrationBuilder.RenameTable(
                name: "CompanyReviews",
                newName: "CompanyReview");

            migrationBuilder.RenameTable(
                name: "CompanyReviewReports",
                newName: "CompanyReviewReport");

            migrationBuilder.RenameTable(
                name: "CompanyReviewReplies",
                newName: "CompanyReviewReply");

            migrationBuilder.RenameTable(
                name: "CompanyReviewReactions",
                newName: "CompanyReviewReaction");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CompanyId",
                table: "Job",
                newName: "IX_Job_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CategoryId",
                table: "Job",
                newName: "IX_Job_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviews_UserId",
                table: "JobReview",
                newName: "IX_JobReview_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviews_JobId",
                table: "JobReview",
                newName: "IX_JobReview_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReports_UserId",
                table: "JobReviewReport",
                newName: "IX_JobReviewReport_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReports_JobReviewId",
                table: "JobReviewReport",
                newName: "IX_JobReviewReport_JobReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReplies_UserId",
                table: "JobReviewReply",
                newName: "IX_JobReviewReply_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReplies_JobReviewId",
                table: "JobReviewReply",
                newName: "IX_JobReviewReply_JobReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReactions_UserId",
                table: "JobReviewReaction",
                newName: "IX_JobReviewReaction_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobReviewReactions_JobReviewId",
                table: "JobReviewReaction",
                newName: "IX_JobReviewReaction_JobReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_CandidateId",
                table: "Experience",
                newName: "IX_Experience_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_CandidateId",
                table: "Education",
                newName: "IX_Education_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanySocialLinks_CompanyId",
                table: "CompanySocialLink",
                newName: "IX_CompanySocialLink_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviews_UserId",
                table: "CompanyReview",
                newName: "IX_CompanyReview_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviews_CompanyId",
                table: "CompanyReview",
                newName: "IX_CompanyReview_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReports_UserId",
                table: "CompanyReviewReport",
                newName: "IX_CompanyReviewReport_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReports_CompanyReviewId",
                table: "CompanyReviewReport",
                newName: "IX_CompanyReviewReport_CompanyReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReplies_UserId",
                table: "CompanyReviewReply",
                newName: "IX_CompanyReviewReply_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReplies_CompanyReviewId",
                table: "CompanyReviewReply",
                newName: "IX_CompanyReviewReply_CompanyReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReactions_UserId",
                table: "CompanyReviewReaction",
                newName: "IX_CompanyReviewReaction_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyReviewReactions_CompanyReviewId",
                table: "CompanyReviewReaction",
                newName: "IX_CompanyReviewReaction_CompanyReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_UserId",
                table: "Company",
                newName: "IX_Company_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_UserId",
                table: "Candidate",
                newName: "IX_Candidate_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReview",
                table: "JobReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviewReport",
                table: "JobReviewReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviewReply",
                table: "JobReviewReply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobReviewReaction",
                table: "JobReviewReaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanySocialLink",
                table: "CompanySocialLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReview",
                table: "CompanyReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviewReport",
                table: "CompanyReviewReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviewReply",
                table: "CompanyReviewReply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReviewReaction",
                table: "CompanyReviewReaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Users_UserId",
                table: "Candidate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_UserId",
                table: "Company",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReview_Company_CompanyId",
                table: "CompanyReview",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReview_Users_UserId",
                table: "CompanyReview",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReaction_CompanyReview_CompanyReviewId",
                table: "CompanyReviewReaction",
                column: "CompanyReviewId",
                principalTable: "CompanyReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReaction_Users_UserId",
                table: "CompanyReviewReaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReply_CompanyReview_CompanyReviewId",
                table: "CompanyReviewReply",
                column: "CompanyReviewId",
                principalTable: "CompanyReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReply_Users_UserId",
                table: "CompanyReviewReply",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReport_CompanyReview_CompanyReviewId",
                table: "CompanyReviewReport",
                column: "CompanyReviewId",
                principalTable: "CompanyReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyReviewReport_Users_UserId",
                table: "CompanyReviewReport",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySocialLink_Company_CompanyId",
                table: "CompanySocialLink",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Candidate_CandidateId",
                table: "Education",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Candidate_CandidateId",
                table: "Experience",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Category_CategoryId",
                table: "Job",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReview_Job_JobId",
                table: "JobReview",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReview_Users_UserId",
                table: "JobReview",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReaction_JobReview_JobReviewId",
                table: "JobReviewReaction",
                column: "JobReviewId",
                principalTable: "JobReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReaction_Users_UserId",
                table: "JobReviewReaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReply_JobReview_JobReviewId",
                table: "JobReviewReply",
                column: "JobReviewId",
                principalTable: "JobReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReply_Users_UserId",
                table: "JobReviewReply",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReport_JobReview_JobReviewId",
                table: "JobReviewReport",
                column: "JobReviewId",
                principalTable: "JobReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviewReport_Users_UserId",
                table: "JobReviewReport",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
