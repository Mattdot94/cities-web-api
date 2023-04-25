    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York",
                    Description = "has the Statue of Liberty",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "Big Ass Park"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Statue Of Liberty",
                            Description = "French Gift to the US"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Paris",
                    Description = "has the Eifell Tower",
                     PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Eifell Tower",
                            Description = "Not as big as you'd think"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Snails",
                            Description = "They love them snails"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Vegas",
                    Description = "The city that never sleeps",
                     PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Casinos",
                            Description = "Money Sinks"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Hoes",
                            Description = "Them hoes ain't loyal"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 4,
                    Name = "Amsterdam",
                    Description = "Red Light District",
                     PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 7,
                            Name = "Red Light District",
                            Description = "You know what it is"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "Coffee Shops",
                            Description = "biggest attraction of all",
                        }
                    }
                },
                new CityDto()
                {
                    Id = 5,
                    Name = "Canada",
                    Description = "Poutine and Ice Hockey",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 9,
                            Name = "Ice Hockey",
                            Description = "Sports"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 10,
                            Name = "Poutine",
                            Description = "Whats not to like"
                        }
                    }
                },
            };
        }
    }
}
