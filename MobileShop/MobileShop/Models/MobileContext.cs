using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Role> Roles { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string moderatorRoleName = "moderator";
            string consultantRoleName = "consultant";

            string adminEmail = "a";
            string adminPassword = "1";

            //add role
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role moderatorRole = new Role { Id = 2, Name = moderatorRoleName };
            Role consultantRole = new Role { Id = 3, Name = consultantRoleName };
            User adminUser = new User { Id = 4, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, moderatorRole, consultantRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
