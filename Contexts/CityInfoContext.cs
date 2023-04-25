using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Contexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
        }

        public DbSet<City> Cities{ get; set; }
        public DbSet<PointsOfInterest> PointsOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                Name = "New York",
                Description = "Statue of Liberty",
            },
            new City
            {
                Id = 2,
                Name = "Paris",
                Description = "Eifell Tower"
            },
            new City
            {
                Id = 3,
                Name = "Vegas",
                Description = "The city that never sleeps"
            });

            modelBuilder.Entity<PointsOfInterest>().HasData(
            new PointsOfInterest
            {
                Id = 1,
                CityId = 1,
                Name = "Central Park",
                Description = "Big Ass Park"
            },
            new PointsOfInterest
            {
                Id = 2,
                CityId = 1,
                Name = "Statue Of Liberty",
                Description = "French Gift to the US"
            },
            new PointsOfInterest
            {
                Id = 3,
                CityId = 2,
                Name = "Eifell Tower",
                Description = "Not as big as you'd think"
            },
            new PointsOfInterest
            {
                Id = 4,
                CityId = 2,
                Name = "Snails",
                Description = "They love them snails"
            },
            new PointsOfInterest
            {
                Id = 5,
                CityId = 3,
                Name = "Casinos",
                Description = "Money Sinks"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}