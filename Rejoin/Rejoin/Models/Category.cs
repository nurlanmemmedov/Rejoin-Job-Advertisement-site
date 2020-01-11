using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Rejoin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Photo { get; set; }

        public List<Job> Jobs { get; set; }
        [NotMapped]
        [Display(Name = "Şəkil yüklə")]
        public IFormFile Upload { get; set; }
    }
}
