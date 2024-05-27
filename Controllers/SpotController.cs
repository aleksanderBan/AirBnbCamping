using AirBnbAPI.Data;
using AirBnbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotController : ControllerBase
    {
        private IAnonymousAirBnbDataContext _data;

        public SpotController(IAnonymousAirBnbDataContext data)
        {
            _data = data;
        }

        //[HttpGet(Name = "GetSpots")]
        //public ActionResult<IEnumerable<Spot>> Get([FromQuery] bool? isAvailable = null)
        //{
        //    var spots = _data.GetSpots();
        //    if (isAvailable.HasValue)
        //    {
        //        spots = spots.Where(s => s.IsAvailable == isAvailable.Value);
        //    }
        //    return Ok(spots);
        //}

        [HttpGet(Name = "GetSpots")]
        public ActionResult<IEnumerable<Spot>> Get()
        {
            return Ok(_data.GetSpots());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Spot spot)
        {
            _data.AddSpot(spot);
            return Ok("Spot added");
        }
    }
}
