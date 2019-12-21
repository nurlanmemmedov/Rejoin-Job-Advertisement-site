using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rejoin.Models;

namespace Rejoin.ViewModels
{
    public class JobViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public JobType JobType { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal MinSalary { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal MaxSalary { get; set; }
        [Required]
        public int MaxExperience { get; set; }
        [Required]
        public int MinExperience { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<JobReview> JobReviews { get; set; }
    }
}
