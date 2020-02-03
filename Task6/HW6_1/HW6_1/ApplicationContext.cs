using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace HW6_1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=44391;Database=usersdb;Username=postgres;Password=password");
        }
    }
}
