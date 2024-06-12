using AirBnbAPI.Models;
using LiteDB;
using System.Collections.Generic;

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

        public void DeleteSpot(int id)
        {
            if (!db.GetCollection<Spot>("Spots").Delete(id))
            {
                throw new KeyNotFoundException($"Spot with ID {id} does not exist.");
            }
        }

        public void AddUser(User user)
        {
            db.GetCollection<User>("Users").Insert(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.GetCollection<User>("Users").FindAll();
        }

        public void UpdateUser(User user)
        {
            db.GetCollection<User>("Users").Update(user);
        }

        public void DeleteBooking(int id)
        {
            if (!db.GetCollection<Booking>("Bookings").Delete(id))
            {
                throw new KeyNotFoundException($"Booking with ID {id} does not exist.");
            }
        }

        public void DeleteUser(int id)
        {
            if (!db.GetCollection<User>("Users").Delete(id))
            {
                throw new KeyNotFoundException($"User with ID {id} does not exist.");
            }
        }

        //Admin shit

        public bool ValidatePassword(string password)
        {
            // Implement your logic to validate the admin password here
            // For simplicity, let's assume the password is hardcoded
            return password == "adminpassword";
        }

        public IEnumerable<Spot> GetAllSpots()
        {
            return db.GetCollection<Spot>("Spots").FindAll();
        }

        public void CreateSpot(Spot spot)
        {
            db.GetCollection<Spot>("Spots").Insert(spot);
        }
    }
}