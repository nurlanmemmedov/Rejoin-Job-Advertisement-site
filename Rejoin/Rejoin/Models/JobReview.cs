using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class JobReview
    {
        public int Id { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        [Range(0, 10)]
        public int Ranking { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }

        public Job Job { get; set; }

        public List<JobReviewReaction> JobReviewReactions { get; set; }
        public List<JobReviewReply> JobReviewReplies { get; set; }
        public List<JobReviewReport> JobReviewReports { get; set; }


    }
}
