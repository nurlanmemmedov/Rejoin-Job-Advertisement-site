using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Token { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public Resume Resume { get; set; }

    }
}
