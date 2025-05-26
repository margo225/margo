using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.Enums;

namespace WpfApp2
{
    public class AplicationDbContext : DbContext
    {
        private static User[] _users =
        {
            new User(){Login="Ivan",Password="1", FIO="Иванов Иван Иванович", Phone="11111111111", Registration=DateOnly.Parse("03.02.2012")},
            new User(){Login="Petr",Password="1", FIO="Петров Петр Петрович", Phone="22222222222", Registration=DateOnly.Parse("04.02.2012")},
            new User(){Login="Roman",Password="1", FIO="Романов Роман Романович", Phone="33333333333", Registration=DateOnly.Parse("05.02.2012")},
            new User(){Login="Nikita",Password="1", FIO="Никитин Ниеита Никитич", Phone="44444444444", Registration=DateOnly.Parse("06.02.2012")},
        };
        private static Book[] _books =
        {
            new Book(){Artikl="dfg1", DateOnly=DateOnly.Parse("03.03.2014"), Description="Description", Janr="1", Name="Name1", status=Status.Выдана, UserId="Ivan" },
            new Book(){Artikl="dfg2", DateOnly=DateOnly.Parse("04.03.2014"), Description="Description", Janr="1", Name="Name2", status=Status.Выдана, UserId="Petr" },
            new Book(){Artikl="dfg3", DateOnly=DateOnly.Parse("04.03.2014"), Description="Description", Janr="1", Name="Name3", status=Status.Выдана, UserId="Roman" },
            new Book(){Artikl="dfg4", DateOnly=DateOnly.Parse("03.03.2014"), Description="Description", Janr="1", Name="Name4", status=Status.Выдана, UserId="Nikita" },
            new Book(){Artikl="dfg6", DateOnly=DateOnly.Parse("05.03.2014"), Description="Description", Janr="1", Name="Name5", status=Status.В_наличии},
            new Book(){Artikl="dfg7", DateOnly=DateOnly.Parse("07.03.2014"), Description="Description", Janr="1", Name="Name6", status=Status.В_наличии},
            new Book(){Artikl="dfg8", DateOnly=DateOnly.Parse("08.03.2014"), Description="Description", Janr="1", Name="Name7", status=Status.В_наличии}
        };
        public DbSet<Book> booksDb {  get; set; }
        public DbSet<User> usersDb { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(_books);
            modelBuilder.Entity<User>().HasData(_users);
            modelBuilder.Entity<Book>().HasOne(b => b.User).WithOne();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("data source=database.db");
        }
        public AplicationDbContext()
        {
            Database.EnsureCreated();
        }
    }
}
