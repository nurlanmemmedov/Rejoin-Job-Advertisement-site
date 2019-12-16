using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Description { get; set; }
        public string JobType { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public int MaxExperience { get; set; }
        public int MinExperience { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public Category Category { get; set; }
        public Company Company { get; set; }
        public string Photo { get; set; }
        public List<JobReview> JobReviews { get; set; }

    }
}
