using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    [ApiController]
    [Route("api/testingTheDB")]
    public class DummyController : ControllerBase
    {
        public CityInfoContext CityInfoContext { get; }

        public DummyController(CityInfoContext cityInfoContext)
        {
            CityInfoContext = cityInfoContext;
        }

        [HttpGet]
        public IActionResult Testing()
        {
            return Ok();
        }
    }
}
