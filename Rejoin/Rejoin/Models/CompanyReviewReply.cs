using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class CompanyReviewReply
    {
        public int Id { get; set; }
        public string Reply { get; set; }
        public int UserId { get; set; }
        public int JobReviewId { get; set; }
        public CompanyReview CompanyReview { get; set; }
        public User User { get; set; }
    }
}
