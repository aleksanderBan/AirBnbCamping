using AirBnbAPI.Models;
using System.Collections.Generic;

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

        public void DeleteSpot(int id)
        {
            var spot = spots.FirstOrDefault(s => s.Id == id);
            if (spot == null)
            {
                throw new KeyNotFoundException($"Spot with ID {id} does not exist.");
            }
            spots.Remove(spot);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public void UpdateUser(User user)
        {
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
            }
        }

        public void DeleteBooking(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with ID {id} does not exist.");
            }
            bookings.Remove(booking);
        }

        public void DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} does not exist.");
            }
            users.Remove(user);
        }
    }
}
