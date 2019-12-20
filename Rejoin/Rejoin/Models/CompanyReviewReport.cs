using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rejoin.Models
{
    public class CompanyReviewReport
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string ReportDesc { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CompanyReviewId { get; set; }
        public CompanyReview CompanyReview { get; set; }
        public User User { get; set; }
    }
}
