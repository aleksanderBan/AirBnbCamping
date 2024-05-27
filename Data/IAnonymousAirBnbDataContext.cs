﻿using AirBnbAPI.Models;

namespace AirBnbAPI.Data
{
    public interface IAnonymousAirBnbDataContext
    {
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();

        void AddSpot(Spot spot);
        IEnumerable<Spot> GetSpots();

        void AddUser(User user);
        IEnumerable<User> GetUsers();

        //void UpdateUser(User user);
    }
}
