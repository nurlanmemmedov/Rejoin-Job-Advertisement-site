using Rejoin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.ViewModels
{
    public class ApplyViewModel
    {
        [Required]

        public string WhyYou { get; set; }
        [Required]
        public DateTime AppliedAt { get; set; }
        [Required]
        public int JobId { get; set; }
        [Required]
        public int CandidateId { get; set; }
        public Job Job { get; set; }
        public Candidate Candidate { get; set; }
    }
}
