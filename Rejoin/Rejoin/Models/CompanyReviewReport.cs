using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class CompanyReviewReport
    {
        public int Id { get; set; }
        public string ReportDesc { get; set; }
        public int UserId { get; set; }
        public int CompanyReviewId { get; set; }
        public CompanyReview CompanyReview { get; set; }
        public User User { get; set; }
    }
}
