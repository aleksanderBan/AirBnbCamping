using AirBnbAPI.Data;
using AirBnbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IAnonymousAirBnbDataContext _data;

        public BookingController(IAnonymousAirBnbDataContext data)
        {
            _data = data;
        }

        [HttpGet(Name = "GetBooking")]
        public ActionResult <IEnumerable<Booking>> Get()
        {
            return Ok(_data.GetBookings());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Booking booking)
        {
            _data.AddBooking(booking);
            return Ok("Hooray");
        }
    }
}