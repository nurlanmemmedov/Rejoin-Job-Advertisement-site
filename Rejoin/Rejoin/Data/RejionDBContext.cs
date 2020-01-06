using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rejoin.Models;

namespace Rejoin.Data
{
    public class RejionDBContext: DbContext
    {
        public RejionDBContext(DbContextOptions<RejionDBContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySocialLink> CompanySocialLinks { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Apply> Applies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
