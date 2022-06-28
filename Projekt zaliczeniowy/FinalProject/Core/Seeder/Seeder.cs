using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Seeder
{
    public class Seeder
    {
        private readonly Entities.AppContext _dbContext;
        public Seeder(Entities.AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Authors.Any())
                {
                    var authors = GetAuthors();
                    _dbContext.Authors.AddRange(authors);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Books.Any())
                {
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Customers.Any())
                {
                    var customers = GetCustomers();
                    _dbContext.Customers.AddRange(customers);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Librarians.Any())
                {
                    var librarians = GetLibrarians();
                    _dbContext.Librarians.AddRange(librarians);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Authors> GetAuthors()
        {
            var authors = new List<Authors>()
            {
                new Authors()
                    {
                        AGID = new Guid(),
                        AFirstName = "Aleksander",
                        AMiddleName = null,
                        ALastName = "Fredro",
                        AFullName = "Aleksander Fredro",
                    },
                new Authors()
                    {
                        AGID = new Guid(),
                        AFirstName = "Henryk",
                        AMiddleName = null,
                        ALastName = "Siekiewicz",
                        AFullName = "Henryk Sienkiewicz",
                    },
                new Authors()
                    {
                        AGID = new Guid(),
                        AFirstName = "Alan",
                        AMiddleName = "Alexander",
                        ALastName = "Milne",
                        AFullName = "Alan Alexander Milne",
                    },
                new Authors()
                    {
                        AGID = new Guid(),
                        AFirstName = "Ernest",
                        AMiddleName = "Miller",
                        ALastName = "Hemingway",
                        AFullName = "Ernest Miller Hemingway",
                    }
            };
            return authors;
        }
        private IEnumerable<Books> GetBooks()
        {
            var books = new List<Books>()
            {
                new Books()
                {
                    BTitle = "Stary człowiek i morze",
                    BISBN = "9788804325963",
                    BPublishDate = new DateTime(1952, 9, 1),
                    //BAuthors = Authors.FirstOrDefault(x => x.AId == 4).AFullName
                },
                new Books()
                {
                    BTitle = "Quo vadis",
                    BISBN = "9788420733838",
                    BPublishDate = new DateTime(1896, 2, 1)
                },
                new Books()
                {
                    BTitle = "Ogniem i Mieczem",
                    BISBN = "9780020820444",
                    BPublishDate = new DateTime(1884, 1, 1)
                },
                new Books()
                {
                    BTitle = "Krzyżacy",
                    BISBN = "9780781801218",
                    BPublishDate = new DateTime(1900, 7, 1)
                },
                new Books()
                {
                    BTitle = "Kubuś Puchatek",
                    BISBN = "9780140361216",
                    BPublishDate = new DateTime(1926, 1, 1)
                },
                new Books()
                {
                    BTitle = "Zemsta",
                    BISBN = "9788304016934",
                    BPublishDate = new DateTime(1834, 1, 1)
                }
            };
            return books;
        }
        private IEnumerable<Customers> GetCustomers()
        {
            var customers = new List<Customers>()
            {
                new Customers()
                {
                    CFirstName = "Mateusz",
                    CLastName = "Kowalski",
                    CCardCode = 123456,
                },
                new Customers()
                {
                    CFirstName = "Anna",
                    CLastName = "Zaradna",
                    CCardCode = 865454,
                },
                new Customers()
                {
                    CFirstName = "Jan",
                    CLastName = "Niezbędny",
                    CCardCode = 234572,
                },
                new Customers()
                {
                    CFirstName = "Filip",
                    CLastName = "Majcher",
                    CCardCode = 645378,
                },
                 new Customers()
                {
                    CFirstName = "Marta",
                    CLastName = "Filipińska",
                    CCardCode = 345123,
                },
            };
            return customers;
        }
        private IEnumerable<Librarians> GetLibrarians()
        {
            var librarians = new List<Librarians>()
            {
                new Librarians()
                {
                    LFirstName = "Mariusz",
                    LLastName = "Duda",
                    LEmail = "mardud@wp.pl"
                },
                new Librarians()
                {
                    LFirstName = "Barabara",
                    LLastName = "Nowak",
                    LEmail = "barbnow123@onet.pl"
                },
                new Librarians()
                {
                    LFirstName = "Karolina",
                    LLastName = "Konieczna",
                    LEmail = "kk@wp.pl"
                },
            };
            return librarians;
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    RName = "User"
                },
                new Role()
                {
                    RName = "Librarian"
                },
                 new Role()
                {
                    RName = "Admin"
                }
            };
            return roles;
        }
    }
}
