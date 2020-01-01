using Microsoft.AspNetCore.Http;
using Rejoin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Rejoin.ViewModels
{
    public class CompanyViewModel
    {


        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "sjdsj";
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Info { get; set; }
        [MaxLength(100)]
        public string Photo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Website { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Location { get; set; }
        public List<CompanyReview> CompanyReviews { get; set; }
        public List<CompanySocialLink> CompanySocialLinks { get; set; }
        public List<Job> Jobs { get; set; }
        public User User { get; set; }
        public IFormFile Upload { get; set; }
    }
}
