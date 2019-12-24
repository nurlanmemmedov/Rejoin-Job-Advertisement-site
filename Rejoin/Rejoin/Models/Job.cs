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
        FullTime =1,
        PartTime = 2,
        Remote = 3,
        Internship = 4
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
        public DateTime CreatedAt { get; set; }
        [Required]
        public int ViewCount { get; set; }
        [Required]
        public int LikeCount { get; set; }
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
        public int MinSalary { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public int MaxSalary { get; set; }
        [Required]
        public int MaxExperience { get; set; }
        [Required]
        public int MinExperience { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Category Category { get; set; }
        public Company Company { get; set; }
        public List<JobReview> JobReviews { get; set; }

    }
}
