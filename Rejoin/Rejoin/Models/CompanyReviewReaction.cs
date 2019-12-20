using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class CompanyReviewReaction
    {
        public int Id { get; set; }
        public bool IsHelpful { get; set; }
        [Required]
        public int CompanyReviewId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public CompanyReview CompanyReview { get; set; }
    }
}
