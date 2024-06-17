using AirBnbAPI.Data;
using AirBnbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AirBnbAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotController : ControllerBase
    {
        private readonly IAnonymousAirBnbDataContext _data;

        public SpotController(IAnonymousAirBnbDataContext data)
        {
            _data = data;
        }

        [HttpGet(Name = "GetSpots")]
        public ActionResult<IEnumerable<Spot>> Get([FromQuery] string location = null, bool? isAvailable = null)
        {
            var spots = _data.GetSpots();

            if (!string.IsNullOrEmpty(location))
            {
                spots = spots.Where(s => s.Location.Contains(location, System.StringComparison.InvariantCultureIgnoreCase));
            }

            if (isAvailable.HasValue)
            {
                spots = spots.Where(s => s.IsAvailable == isAvailable.Value);
            }

            return Ok(spots);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Spot spot)
        {
            _data.AddSpot(spot);
            return Ok("Spot added");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _data.DeleteSpot(id);   
                return Ok("Spot deleted");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
