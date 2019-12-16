using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class CompanyReview
    {
        public int Id { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [Range(0, 5)]
        public int Ranking { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }

        public Company Company { get; set; }

        public List<CompanyReviewReaction> CompanyReviewReactions { get; set; }
        public List<CompanyReviewReply> CompanyReviewReplies { get; set; }
        public List<CompanyReviewReport> CompanyReviewReports { get; set; }
    }
}
