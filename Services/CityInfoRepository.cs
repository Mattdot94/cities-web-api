using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context { get; }

        public CityInfoRepository(CityInfoContext cityInfoContext)
        {
            _context = cityInfoContext;
        }

        public IEnumerable<City> GetCities() => _context.Cities.OrderBy(c => c.Name).ToList();

        public City GetCity(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest).Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterests(int cityId) => _context.PointsOfInterest.Where(c => c.CityId == cityId).ToList();

        public PointsOfInterest GetSinglePointOfInterest(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public bool CityExists(int cityId) => _context.Cities.Any(c => c.Id == cityId);
    }
}