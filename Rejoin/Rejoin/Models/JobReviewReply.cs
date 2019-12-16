using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class JobReviewReply
    {
        public int Id { get; set; }
        public string Reply { get; set; }
        public int UserId { get; set; }
        public int JobReviewId { get; set; }
        public JobReview JobReview { get; set; }
        public User User { get; set; }

    }
}
