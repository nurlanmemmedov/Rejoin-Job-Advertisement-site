using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Profession { get; set; }
        public TimeSpan ExperienceTime { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PersonalSkill { get; set; }

        public int UserId { get; set; }

        public List<string> ProfessionalSkills { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<Education> Educations { get; set; }

        public User User { get; set; }



    }
}
