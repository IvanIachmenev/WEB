using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW6_3
{
    public class StoreContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Water> Water{ get; set; }
        public StoreContext()
        {
               Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=PerfumeStoreNew63;Username=postgres;Password=Aa3sdf&;");
        }
    }
}
