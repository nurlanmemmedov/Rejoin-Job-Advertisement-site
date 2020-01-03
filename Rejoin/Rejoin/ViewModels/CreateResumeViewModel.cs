using Microsoft.AspNetCore.Http;
using Rejoin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.ViewModels
{

    public class CreateResumeViewModel
    {
        public List<EducationViewModel> Educations { get; set; }

    }
    public class ResumeViewModel
    {
        [MaxLength(100)]
        public string Photo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Profession { get; set; }
        [Required]
        public string ExperienceTime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(500)]
        public string PersonalSkill { get; set; }

        public IFormFile Upload { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }

        public List<EducationViewModel> Educations { get; set; }

    }

    public class ExperienceViewModel
    {
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
    }

    public class EducationViewModel
    {
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
    }
}
