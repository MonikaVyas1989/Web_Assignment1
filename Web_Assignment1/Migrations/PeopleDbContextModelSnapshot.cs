﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Assignment1.Data;

namespace Web_Assignment1.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    partial class PeopleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_Assignment1.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 2,
                            Name = "David",
                            Phone = "+462215424243"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 1,
                            Name = "Malin",
                            Phone = "+461234455678"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 2,
                            Name = "Olga",
                            Phone = "+462215424789"
                        },
                        new
                        {
                            PersonId = 4,
                            CityId = 3,
                            Name = "Rasool",
                            Phone = "+469821542424"
                        });
                });

            modelBuilder.Entity("Web_Assignment1.ViewModels.CityViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Varberg"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Halmstad"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 3,
                            Name = "Copenhagen"
                        });
                });

            modelBuilder.Entity("Web_Assignment1.ViewModels.CountryViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Norwe"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Denmark"
                        });
                });

            modelBuilder.Entity("Web_Assignment1.Models.PersonModel", b =>
                {
                    b.HasOne("Web_Assignment1.ViewModels.CityViewModel", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web_Assignment1.ViewModels.CityViewModel", b =>
                {
                    b.HasOne("Web_Assignment1.ViewModels.CountryViewModel", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
