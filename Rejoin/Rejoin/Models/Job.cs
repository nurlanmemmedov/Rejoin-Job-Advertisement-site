using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public enum JobType
    {
        FullTime,
        PartTime,
        Remote,
        Internship
    }
    public class Job
    {
        public int Id { get; set; }
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
        public int Description { get; set; }
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
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Photo { get; set; }
        public Category Category { get; set; }
        public Company Company { get; set; }
        public List<JobReview> JobReviews { get; set; }

    }
}
