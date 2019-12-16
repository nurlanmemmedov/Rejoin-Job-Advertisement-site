using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 xarakter ola bilər")]
        [MinLength(6, ErrorMessage = "Minimum 6 xarakter ola bilər")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
