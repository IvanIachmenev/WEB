using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HW5.Models
{
    public class AplicationContext : DbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
