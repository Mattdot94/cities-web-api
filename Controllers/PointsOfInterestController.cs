using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]

    public class PointsOfInterestController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public ILogger<PointsOfInterestController> Logger { get; }

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, ICityInfoRepository cityInfoRepository)
        {
            Logger = logger;
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                if (!_cityInfoRepository.CityExists(cityId))
                {
                    Logger.LogInformation($"City with Id: {cityId} wasn't found when accessing poi");
                    return NotFound();
                }

                var pointsOfInterestForCity = _cityInfoRepository.GetPointsOfInterests(cityId);

                var pointsOfInterestforCityResults = new List<PointOfInterestDto>();

                foreach (var poi in pointsOfInterestForCity)
                {
                    pointsOfInterestforCityResults.Add(new PointOfInterestDto
                    {
                        Id = poi.Id,
                        Name = poi.Name,
                        Description = poi.Description
                    });
                }

                return Ok(pointsOfInterestforCityResults);
            }
            catch (Exception ex)
            {
                Logger.LogCritical($"Something went wrong while getting points of interest for city with id: {cityId}", ex);
                return StatusCode(500, "Something went wrong while handling your request");
            }
        }

        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityiD, int id)
        {
            if (!_cityInfoRepository.CityExists(cityiD))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetSinglePointOfInterest(cityiD, id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            var pointOfInterestResult = new PointOfInterestDto()
            {
                Id = pointOfInterest.Id,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            return Ok(pointOfInterestResult);
        }

        [HttpPost]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var getId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var newPointOfInterest = new PointOfInterestDto()
            {
                Id = ++getId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(newPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = newPointOfInterest.Id }, newPointOfInterest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestToUpdate = city.PointsOfInterest.First(p => p.Id == id);
            if (pointOfInterestToUpdate == null)
            {
                return NotFound();
            }

            pointOfInterestToUpdate.Name = pointOfInterest.Name;
            pointOfInterestToUpdate.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromDB = city.PointsOfInterest.First(p => p.Id == id);
            if (pointOfInterestFromDB == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromDB.Name,
                Description = pointOfInterestFromDB.Description
            };

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromDB.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromDB.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestToDelete = city.PointsOfInterest.SingleOrDefault(p => p.Id == id);

            if (pointOfInterestToDelete == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestToDelete);

            return NoContent();
        }
    }
}