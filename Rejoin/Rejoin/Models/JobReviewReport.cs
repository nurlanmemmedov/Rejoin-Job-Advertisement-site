using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Rejoin.Models;

namespace Rejoin.Models
{
    public class JobReviewReport
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string ReportDesc { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int JobReviewId { get; set; }
        public JobReview JobReview { get; set; }
        public User User { get; set; }

    }
}
