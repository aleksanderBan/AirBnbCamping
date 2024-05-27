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

        public void AddSpot(Spot spot)
        {
            db.GetCollection<Spot>("Spots").Insert(spot);
        }

        public IEnumerable<Spot> GetSpots()
        {
            return db.GetCollection<Spot>("Spots").FindAll();
        }

        public void AddUser(User user)
        {
            db.GetCollection<User>("Users").Insert(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.GetCollection<User>("Users").FindAll();
        }

        //public void UpdateUser(User user)
        //{
        //    db.GetCollection<User>("Users").Update(user);
        //}
    }
}
