using Microsoft.AspNetCore.Http;
using Rejoin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Rejoin.ViewModels
{
    public class CompanyViewModel
    {


        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Name { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(500, ErrorMessage = "Maksimum 500 xarakter ola bilər")]
        public string Info { get; set; }
        [MaxLength(500, ErrorMessage = "Maksimum 500 xarakter ola bilər")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 500 xarakter ola bilər")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 500 xarakter ola bilər")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 500 xarakter ola bilər")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(200, ErrorMessage = "Maksimum 500 xarakter ola bilər")]
        public string Location { get; set; }
        public List<CompanySocialLink> CompanySocialLinks { get; set; }
        public List<Job> Jobs { get; set; }
        public User User { get; set; }
        public IFormFile Upload { get; set; }
    }
}
