using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Rejoin.Models;

namespace Rejoin.Models
{
    public class Apply
    {
        public int Id { get; set; }
        [Required]
        public string WhyYou { get; set; }
        [Required]
        public int JobId { get; set; }
        [Required]
        public int UserId { get; set; }
        public Job Job { get; set; }
        public User User { get; set; }

    }
}
