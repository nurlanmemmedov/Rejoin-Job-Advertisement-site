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
    }
}
