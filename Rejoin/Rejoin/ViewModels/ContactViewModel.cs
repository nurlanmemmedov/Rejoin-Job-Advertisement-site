using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(500, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Message { get; set; }
    }
}
