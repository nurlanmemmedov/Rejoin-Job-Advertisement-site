using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class Education
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string SchoolName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Qualification { get; set; }
        [Required]
        public string StartedAt { get; set; }
        [Required]
        public string FinishedAt { get; set; }
        public string University { get; set; }
        [Required]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

    }
}
