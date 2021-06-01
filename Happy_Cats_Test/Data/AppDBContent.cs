using Happy_Cats_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy_Cats_Test.Data
{
    public class AppDBContent : DbContext
    {

        public DbSet<Cats> Cats { get; set; }
        public DbSet<Users> Users { get; set; }

        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
