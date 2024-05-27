using AirBnbAPI.Models;

namespace AirBnbAPI.Data
{
    public class AnonymousAirBnbDataList : IAnonymousAirBnbDataContext
    {
        List<Booking> bookings = new List<Booking>();
        List<Spot> spots = new List<Spot>();
        List<User> users = new List<User>();

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return bookings;
        }

        public void AddSpot(Spot spot)
        {
            spots.Add(spot);
        }

        public IEnumerable<Spot> GetSpots()
        {
            return spots;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        //public void UpdateUser(User user)
        //{
        //    var index = users.FindIndex(u => u.Id == user.Id);
        //    if (index != -1)
        //    {
        //        users[index] = user;
        //    }
        //}
    }
}
