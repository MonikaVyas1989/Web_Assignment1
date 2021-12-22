using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Assignment1.Models;
using Web_Assignment1.ViewModels;

namespace Web_Assignment1.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext>options):base(options)
        {

        }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<CityViewModel> Cities { get; set; }
        public DbSet<CountryViewModel> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>()
                .HasOne(p => p.City)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.CityId)
                .IsRequired();

            modelBuilder.Entity<CityViewModel>()
                .HasOne(co => co.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(co => co.CountryId)
                .IsRequired();



            modelBuilder.Entity<CountryViewModel>().HasData(new CountryViewModel { Id = 1, Name = "Sweden" });
            modelBuilder.Entity<CountryViewModel>().HasData(new CountryViewModel { Id = 2, Name = "Norwe" });
            modelBuilder.Entity<CountryViewModel>().HasData(new CountryViewModel { Id = 3, Name = "Denmark" });

            modelBuilder.Entity<CityViewModel>().HasData(new CityViewModel { Id = 1, Name = "Varberg", CountryId = 1 });
            modelBuilder.Entity<CityViewModel>().HasData(new CityViewModel { Id = 2, Name = "Halmstad", CountryId = 1 });
            modelBuilder.Entity<CityViewModel>().HasData(new CityViewModel { Id = 3, Name = "Oslo", CountryId = 2 });
            modelBuilder.Entity<CityViewModel>().HasData(new CityViewModel { Id = 4, Name = "Copenhagen", CountryId = 3 });

            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "David", Phone = "+462215424243", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "Malin", Phone = "+461234455678", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Olga", Phone = "+462215424789", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 4, Name = "Rasool", Phone = "+469821542424", CityId = 3 });
            

            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "David", Phone = "+462215424243", City = "Göteborg" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Malin", Phone = "+461234455678", City = "Halmstad" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Olga",  Phone = "+462215424789", City = "Halmstad" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Rasool", Phone = "+469821542424", City = "Varberg" });
        }

    }
}
