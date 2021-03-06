using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppContext : DbContext
    {
        public DbSet<Librarians> Librarians { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public AppContext(DbContextOptions options) : base(options)
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-51V4NLA\\SQLEXPRESS;Database=Projekt;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projekt;Trusted_Connection=True;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(x =>
        //        {
        //            x.Property(x => x.UEmail);
        //            x.Property(x => x.ULogin);
        //            x.Property(x => x.UPassword);
        //            x.Property(x => x.UFirstName);
        //            x.Property(x => x.ULastName);
        //        }
        //    );
        //}
    }
}
