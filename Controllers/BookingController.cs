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

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Booking>> GetByUser(int userId)
        {
            var bookings = _data.GetBookings().Where(b => b.UserId == userId);
            return Ok(bookings);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Booking booking)
        {
            //// Assuming userId is passed in the booking request body
            //if (booking.UserId == 1)
            //{
            //    return BadRequest("UserId is required");
            //}

            //_data.AddBooking(booking);
            //return Ok("Booking created");
            // Check if the userId exists
            var existingUser = _data.GetUsers().FirstOrDefault(u => u.Id == booking.UserId);
            if (existingUser == null)
            {
                return BadRequest("UserId does not exist");
            }

            // Check if the spotId exists
            var existingSpot = _data.GetSpots().FirstOrDefault(s => s.Id == booking.SpotId);
            if (existingSpot == null)
            {
                return BadRequest("SpotId does not exist");
            }

            _data.AddBooking(booking);
            return Ok("Booking created");
        }
    }
}