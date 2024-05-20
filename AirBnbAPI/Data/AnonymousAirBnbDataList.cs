using AirBnbAPI.Models;

namespace AirBnbAPI.Data
{
    public class AnonymousAirBnbDataList : IAnonymousAirBnbDataContext
    {
        List<Booking> bookings = new List<Booking>();

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return bookings;
        }
    }
}
