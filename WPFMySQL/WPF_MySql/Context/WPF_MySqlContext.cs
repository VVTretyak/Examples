using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MySql.Model;

namespace WPF_MySql.Context
{
    public class WPF_MySqlContext:DbContext
    {
        public DbSet<Person> Person { get; set; }

        public WPF_MySqlContext()
        {
            try
            {
                Database.EnsureCreated();

            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=People;user=root;password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }

    }
}
