using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DBContext : DbContext
    {
        public DbSet<Librarians> Librarians { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PK6-10\\mssqllocaldb;Database=Projekt;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<Books>().HasData(
                //new Authors
                //{
                    //AId = 1,
                    //AGID = new Guid(),
                    //AFirstName = "Aleksander",
                    //AMiddleName = null,
                    //ALastName = "Fredro",
                    //AFullName = "Aleksander Fredro",
                //},
                //new Authors
                //{
                    //AId = 2,
                    //AGID = new Guid(),
                    //AFirstName = "Henryk",
                    //AMiddleName = null,
                    //ALastName = "Siekiewicz",
                    //AFullName = "Henryk Sienkiewicz",
                //},
                //new Authors
                //{
                    //AId = 3,
                    //AGID = new Guid(),
                    //AFirstName = "Alan",
                    //AMiddleName = "Alexander",
                    //ALastName = "Milne",
                    //AFullName = "Alan Alexander Milne",
                //},
                //new Authors
                //{
                    //AId = 4,
                    //AGID = new Guid(),
                    //AFirstName = "Ernest",
                    //AMiddleName = "Miller",
                    //ALastName = "Hemingway",
                    //AFullName = "Ernest Miller Hemingway",
                //}
           //);

            //modelBuilder.Entity<Books>().HasData(
                //new Books
                //{
                   //BId = 1,
                   //BTitle = "Stary człowiek i morze",
                   //BISBN = "9788804325963",
                   //BPublishDate = new DateTime(1, 9, 1952),
                   ////BAuthors = Authors.FirstOrDefault(x => x.AId == 4).AFullName
                //},
                //new Books
                //{
                    //BId = 2,
                    //BTitle = "Quo vadis",
                    //BISBN = "9788420733838",
                    //BPublishDate = new DateTime(1, 2, 1896)
                //},
                //new Books
                //{
                    //BId = 3,
                    //BTitle = "Ogniem i Mieczem",
                    //BISBN = "9780020820444",
                    //BPublishDate = new DateTime(1, 1, 1884)
                //},
                //new Books
                //{
                    //BId = 4,
                    //BTitle = "Krzyżacy",
                    //BISBN = "9780781801218",
                    //BPublishDate = new DateTime(1, 7, 1900)
                //},
                //new Books
                //{
                    //BId = 5,
                    //BTitle = "Kubuś Puchatek",
                    //BISBN = "9780140361216",
                    //BPublishDate = new DateTime(1, 1, 1926)
                //},
                //new Books
                //{
                    //BId = 6,
                    //BTitle = "Zemsta",
                    //BISBN = "9788304016934",
                    //BPublishDate = new DateTime(1, 1, 1834)
                //}
            //);
        //}
    }
}
