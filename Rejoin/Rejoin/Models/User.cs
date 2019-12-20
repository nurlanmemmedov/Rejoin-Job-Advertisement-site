using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public enum UserType
    {
        Employee,
        Company,
    }
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Token { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
        public Candidate Candidate { get; set; }
        public Company Company { get; set; }
        public List<JobReview> JobReviews { get; set; }
        public List<JobReviewReaction> JobReviewReactions { get; set; }
        public List<JobReviewReply> JobReviewReplies { get; set; }
        public List<JobReviewReport> JobReviewReports { get; set; }
        public List<CompanyReview> CompanyReviews { get; set; }
        public List<CompanyReviewReaction> CompanyReviewReactions { get; set; }
        public List<CompanyReviewReply> CompanyReviewReplies { get; set; }
        public List<CompanyReviewReport> CompanyReviewReports { get; set; }

    }
}
