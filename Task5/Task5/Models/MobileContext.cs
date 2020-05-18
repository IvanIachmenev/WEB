using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Task5.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Company> Companies { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
