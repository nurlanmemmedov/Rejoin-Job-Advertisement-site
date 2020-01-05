using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Rejoin.Models;

namespace Rejoin.Models
{
    public class Apply
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
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
