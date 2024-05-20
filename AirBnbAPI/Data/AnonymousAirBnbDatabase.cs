using AirBnbAPI.Models;
using LiteDB;

namespace AirBnbAPI.Data
{
    public class AnonymousAirBnbDatabase : IAnonymousAirBnbDataContext
    {
        LiteDatabase db = new LiteDatabase(@"data.db");

        public void AddBooking(Booking booking)
        {
            db.GetCollection<Booking>("Bookings").Insert(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return db.GetCollection<Booking>("Bookings").FindAll();
        }
    }
}
