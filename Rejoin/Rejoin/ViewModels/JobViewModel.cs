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
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string City { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(200, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(500, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public JobType JobType { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [Column(TypeName = "money")]
        public int MinSalary { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [Column(TypeName = "money")]
        public int MaxSalary { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public int MaxExperience { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public int MinExperience { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public DateTime CreatedAt{ get; set; }
        public Company Company { get; set; }

        public Category Category { get; set; }
    }
}
