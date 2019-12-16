using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class Education
    {
        public int Id { get; set; }

        public string SchoolName { get; set; }

        public string Qualification { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string University { get; set; }
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }

    }
}
