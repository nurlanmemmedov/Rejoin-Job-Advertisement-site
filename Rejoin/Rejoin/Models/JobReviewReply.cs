using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class JobReviewReply
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Reply { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int JobReviewId { get; set; }
        public JobReview JobReview { get; set; }
        public User User { get; set; }

    }
}
