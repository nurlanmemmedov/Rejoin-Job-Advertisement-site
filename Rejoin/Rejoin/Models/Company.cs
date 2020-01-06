using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Rejoin.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
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
        public List<CompanySocialLink> CompanySocialLinks { get; set; }
        public List<Job> Jobs { get; set; }
        public User User { get; set; }
        [NotMapped]
        [Display(Name = "Şəkil yüklə")]
        public IFormFile Upload { get; set; }


    }
}
