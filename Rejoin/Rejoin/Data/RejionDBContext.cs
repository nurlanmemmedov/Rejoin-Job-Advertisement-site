using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rejoin.Models;

namespace Rejoin.Data
{
    public class RejionDBContext: DbContext
    {
        public RejionDBContext(DbContextOptions<RejionDBContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyReview> CompanyReviews { get; set; }
        public DbSet<CompanyReviewReaction> CompanyReviewReactions { get; set; }
        public DbSet<CompanyReviewReply> CompanyReviewReplies { get; set; }
        public DbSet<CompanyReviewReport> CompanyReviewReports { get; set; }
        public DbSet<CompanySocialLink> CompanySocialLinks { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobReview> JobReviews { get; set; }
        public DbSet<JobReviewReaction> JobReviewReactions { get; set; }
        public DbSet<JobReviewReply> JobReviewReplies { get; set; }
        public DbSet<JobReviewReport> JobReviewReports { get; set; }
    }
}
