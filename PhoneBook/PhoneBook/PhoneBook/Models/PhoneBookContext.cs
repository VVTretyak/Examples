using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models
{
    class PhoneBookContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PhoneBookContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BUF0ESA\WINCCFLEX2014;Database=PhoneBook;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailAddress>()
                .HasOne(p => p.person)
                .WithMany(t => t.EmailAddresses)
                .OnDelete(DeleteBehavior.Cascade);//Каскадное удаление, удаляется person и удаляется EmailAddresses этой персоны
                // .OnDelete(DeleteBehavior.SetNull);//Настройка заполнения колонками Null если будет удалена сущность person
                // то в таблице EmailAddresses установится NULL на месте где стоял Id персоны

            modelBuilder.Entity<PhoneNumber>()
               .HasOne(p => p.person)
               .WithMany(t => t.PhoneNumbers)
               .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
