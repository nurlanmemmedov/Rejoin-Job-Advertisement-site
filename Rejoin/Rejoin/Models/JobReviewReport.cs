using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rejoin.Models;

namespace Rejoin.Models
{
    public class JobReviewReport
    {
        public int Id { get; set; }
        public string ReportDesc { get; set; }
        public int UserId { get; set; }
        public int JobReviewId { get; set; }
        public JobReview JobReview { get; set; }
        public User User { get; set; }

    }
}
