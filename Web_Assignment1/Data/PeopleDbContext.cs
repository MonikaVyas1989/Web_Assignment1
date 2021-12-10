using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Assignment1.Models;

namespace Web_Assignment1.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext>options):base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "David", Phone = "+462215424243", City = "Göteborg" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Malin", Phone = "+461234455678", City = "Halmstad" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Olga",  Phone = "+462215424789", City = "Halmstad" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Rasool", Phone = "+469821542424", City = "Varberg" });
        }

    }
}
