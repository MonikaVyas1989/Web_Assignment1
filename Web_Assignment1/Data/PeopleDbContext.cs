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
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        //public DbSet<Language> Languages { get; set; }
        //public DbSet<PersonLanguage> PersonLanguages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PersonModel>()
                .HasOne(p => p.City)
                .WithMany(ci => ci.People)
                .HasForeignKey(p => p.CityId)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasOne(co => co.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(co => co.CountryId)
                .IsRequired();


            //modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.LanguageId, pl.PersonId });

            //modelBuilder.Entity<PersonLanguage>()
            //    .HasOne(pl => pl.Person)
            //    .WithMany(p => p.People)
            //    .HasForeignKey(pl => pl.PersonId)
            //    .IsRequired();

            //modelBuilder.Entity<PersonLanguage>()
            //    .HasOne(pl => pl.Language)
            //    .WithMany(l => l.People)
            //    .HasForeignKey(l => l.LanguageId)
            //    .IsRequired();



            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Norwe" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Denmark" });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Varberg", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Halmstad", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Oslo", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Copenhagen", CountryId = 3 });

            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "David", Phone = "+462215424243", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "Malin", Phone = "+461234455678", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Olga", Phone = "+462215424789", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 4, Name = "Rasool", Phone = "+469821542424", CityId = 3 });

            //modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Name = "Swedish" });
            //modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Name = "Denish" });
            //modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Name = "Norwegian" });

            //modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 1 });
            //modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 2, LanguageId = 1 });
            //modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 3, LanguageId = 1 });
            //modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 4, LanguageId = 2 });
            //modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 2 });

            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "David", Phone = "+462215424243", City = "Göteborg" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Malin", Phone = "+461234455678", City = "Halmstad" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Olga",  Phone = "+462215424789", City = "Halmstad" });
            //modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, Name = "Rasool", Phone = "+469821542424", City = "Varberg" });
        }

    }
}
