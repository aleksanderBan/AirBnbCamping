using AirBnbAPI.Models;
using LiteDB;
using System.Collections.Generic;

namespace AirBnbAPI.Data
{
    public class AnonymousAirBnbDatabase : IAnonymousAirBnbDataContext
    {
        LiteDatabase db = new LiteDatabase(@"data.db");


        //Booking things
        public void AddBooking(Booking booking)
        {
            db.GetCollection<Booking>("Bookings").Insert(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return db.GetCollection<Booking>("Bookings").FindAll();
        }

        public void DeleteBooking(int id)
        {
            if (!db.GetCollection<Booking>("Bookings").Delete(id))
            {
                throw new KeyNotFoundException($"Booking with ID {id} does not exist.");
            }
        }


        //Spot things
        public void AddSpot(Spot spot)
        {
            db.GetCollection<Spot>("Spots").Insert(spot);
        }

        public IEnumerable<Spot> GetSpots()
        {
            return db.GetCollection<Spot>("Spots").FindAll();
        }

        public Spot GetSpotById(int id)
        {
            return db.GetCollection<Spot>("Spots").FindById(id);
        }

        public void UpdateSpot(Spot spot)
        {
            db.GetCollection<Spot>("Spots").Update(spot);
        }

        public void DeleteSpot(int id)
        {
            if (!db.GetCollection<Spot>("Spots").Delete(id))
            {
                throw new KeyNotFoundException($"Spot with ID {id} does not exist.");
            }
        }


        //User things
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

        public void DeleteUser(int id)
        {
            if (!db.GetCollection<User>("Users").Delete(id))
            {
                throw new KeyNotFoundException($"User with ID {id} does not exist.");
            }
        }


        //Admin things
        public bool ValidatePassword(string password)
        {
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