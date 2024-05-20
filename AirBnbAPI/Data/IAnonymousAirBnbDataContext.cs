using AirBnbAPI.Models;

namespace AirBnbAPI.Data
{
    public interface IAnonymousAirBnbDataContext
    {
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
    }
}
