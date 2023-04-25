using CityInfo.API.Entities;
using System.Collections.Generic;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointOfInterest);
        PointsOfInterest GetSinglePointOfInterest(int cityId, int pointOfInterestId);
        IEnumerable<PointsOfInterest> GetPointsOfInterests(int cityId);
        bool CityExists(int cityId);
    }
}
