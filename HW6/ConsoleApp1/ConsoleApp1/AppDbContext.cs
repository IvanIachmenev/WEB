using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class AppDbContext : DbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=task6db;Trusted_Connection=True;");
        }
    }
}
