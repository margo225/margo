using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V2.Models;

namespace V2
{
    public class AplicationDbContext : DbContext
    {
        public static readonly User[] _users =
        {
            new User(){Id=1, Login="Ivan", Password="1", DateOnlyRegistration=DateOnly.FromDateTime(DateTime.Now), FIO="Ivanov Ivan Ivanovich", PhoneNumber="1" },
            new User(){Id=2, Login="Petr", Password="1", DateOnlyRegistration=DateOnly.FromDateTime(DateTime.Now), FIO="Ivanov Petr Ivanovich", PhoneNumber="2" },
            new User(){Id=3, Login="Roman", Password="1", DateOnlyRegistration=DateOnly.FromDateTime(DateTime.Now), FIO="Ivanov Roman Ivanovich", PhoneNumber="3" }
        };
        public static readonly Inventory[] _inventories =
        {
            new Inventory(){ Id=1, Artikl="1fh", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description1", Name="1", Type="1", Status=Enums.Status.выдана, IdUser=1 },
            new Inventory(){ Id=2, Artikl="2dsfh", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description2", Name="2", Type="2", Status=Enums.Status.выдана, IdUser=1 },
            new Inventory(){ Id=3, Artikl="3sfg", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description3", Name="3", Type="4", Status=Enums.Status.выдана, IdUser=2 },
            new Inventory(){ Id=4, Artikl="4eyr", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description4", Name="4", Type="1", Status=Enums.Status.выдана, IdUser=3 },
            new Inventory(){ Id=5, Artikl="5bm", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description5", Name="5", Type="5", Status=Enums.Status.в_наличии},
            new Inventory(){ Id=6, Artikl="6yiut", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description6", Name="6", Type="3", Status=Enums.Status.в_наличии },
            new Inventory(){ Id=7, Artikl="7khg", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description7", Name="7", Type="2", Status=Enums.Status.в_наличии },
            new Inventory(){ Id=8, Artikl="8xgn", DateOnly=DateOnly.FromDateTime(DateTime.Now), Description="Description8", Name="8", Type="3", Status=Enums.Status.в_наличии }
        };
        public DbSet<User> usersDb {  get; set; }
        public DbSet<Inventory> inventoryDb { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(_users);
            modelBuilder.Entity<Inventory>().HasData(_inventories);
            modelBuilder.Entity<Inventory>().HasOne(i => i.User).WithMany(u => u.Inventory).HasForeignKey(i => i.IdUser); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("data source = database");
        }
        public AplicationDbContext()
        {
            Database.EnsureCreated();
        }
    }
}
