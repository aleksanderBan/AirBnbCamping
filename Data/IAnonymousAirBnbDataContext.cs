using AirBnbAPI.Models;

namespace AirBnbAPI.Data
{
    public interface IAnonymousAirBnbDataContext
    {
        //Booking
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
        void DeleteBooking(int id);


        //Spot
        void AddSpot(Spot spot);
        IEnumerable<Spot> GetSpots();
        void DeleteSpot(int id);
        Spot GetSpotById(int id);
        void UpdateSpot(Spot spot);


        //User
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        void DeleteUser(int id);


        //Admin
        bool ValidatePassword(string password);
        IEnumerable<Spot> GetAllSpots();
        void CreateSpot(Spot spot);
    }
}
