using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Rejoin.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Photo { get; set; }
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
        [Required]
        public int UserId { get; set; }

        public List<Experience> Experiences { get; set; }
        public List<Apply> Applies { get; set; }

        public List<Education> Educations { get; set; }

        public User User { get; set; }

        [NotMapped]
        [Display(Name = "Şəkil yüklə")]

        public IFormFile Upload { get; set; }

    }
}
