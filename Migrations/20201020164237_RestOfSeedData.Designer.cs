﻿// <auto-generated />
using CityInfo.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20201020164237_RestOfSeedData")]
    partial class RestOfSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 1, Description = "Statue of Liberty", Name = "New York" },
                        new { Id = 2, Description = "Eifell Tower", Name = "Paris" },
                        new { Id = 3, Description = "The city that never sleeps", Name = "Vegas" }
                    );
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointsOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new { Id = 1, CityId = 1, Description = "Big Ass Park", Name = "Central Park" },
                        new { Id = 2, CityId = 1, Description = "French Gift to the US", Name = "Statue Of Liberty" },
                        new { Id = 3, CityId = 2, Description = "Not as big as you'd think", Name = "Eifell Tower" },
                        new { Id = 4, CityId = 2, Description = "They love them snails", Name = "Snails" },
                        new { Id = 5, CityId = 3, Description = "Money Sinks", Name = "Casinos" },
                        new { Id = 6, CityId = 3, Description = "Them hoes ain't loyal", Name = "Hoes" }
                    );
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointsOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
