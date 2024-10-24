using AspireApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure.Data
{
    public class AspireAppDbContext: DbContext
    {
        public AspireAppDbContext(DbContextOptions<AspireAppDbContext> options)
        {
            
        }

        // Define a DbSet for each entity you want to store in the database
        public DbSet<User> Users { get; set; }
    }
}
