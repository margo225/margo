using Kontrol.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrol
{
    public class AplicationDbContext : DbContext
    {
        public static readonly User[] _users =
        {
            new User(){Login="Ivan",Password="1",DateRegistration=DateOnly.Parse("10.02.2009"), FIO="Иванов Иван Иванович", Phone="80000000000"},
            new User(){Login="Petr",Password="1",DateRegistration=DateOnly.Parse("15.03.2014"), FIO="Петров Петр Петрович", Phone="80000000001"},
            new User(){Login="Roman",Password="1",DateRegistration=DateOnly.Parse("19.11.2020"), FIO="Романов Роман Романович", Phone="80000000002"}
        };
        public static readonly Shape[] _shapes =
        {
            new Shape(){Articl="A224G", ShortDescription="short Description", Description="Long Long Long Description", DateRegistration=DateOnly.Parse("20.02.2025"),Type="1", Status=Enums.Status.выполнено, UserLogin="Ivan"},
            new Shape(){Articl="HY85f", ShortDescription="short Description", Description="Long Long Long Description", DateRegistration=DateOnly.Parse("25.03.2025"),Type="2", Status=Enums.Status.выполнено, UserLogin="Petr"},
            new Shape(){Articl="78Kl", ShortDescription="short Description", Description="Long Long Long Description", DateRegistration=DateOnly.Parse("30.04.2025"),Type="1", Status=Enums.Status.в_исполнении, UserLogin="Roman"}
        };
        public DbSet<User> users { get; set; }
        public DbSet<Shape> shapes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(_users);
            modelBuilder.Entity<Shape>().HasData(_shapes);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = datebase.db");
        }
        public AplicationDbContext()
        {
            Database.EnsureCreated();
        }
    }
}
