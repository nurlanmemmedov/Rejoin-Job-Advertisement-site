using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Rejoin.Models;

namespace Rejoin.Models
{
    public class CompanySocialLink
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int OrderBy { get; set; }
        [Required]
        [MaxLength(50)]
        public string Url { get; set; }
        public Company Company { get; set; }
    }
}
