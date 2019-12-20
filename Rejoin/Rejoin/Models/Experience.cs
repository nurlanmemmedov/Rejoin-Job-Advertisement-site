using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class Experience
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Position { get; set; }
        [Required]
        public string StartedAt { get; set; }
        [Required]
        public string FinishedAt { get; set; }
        [Required]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
