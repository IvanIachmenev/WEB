using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasl6_3.Models
{
    public class AppContext: DbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }
        public AppContext()
        {
            //ADatabase.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=task6_3;Trusted_Connection=True;");
        }
    }
}
