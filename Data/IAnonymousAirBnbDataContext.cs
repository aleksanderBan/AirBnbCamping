using AirBnbAPI.Models;

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
        void DeleteUser(int id);
        void DeleteSpot(int id);
        void DeleteBooking(int id);

        //void UpdateUser(User user);

        bool ValidatePassword(string password);
        IEnumerable<Spot> GetAllSpots();
        void CreateSpot(Spot spot);
    }
}
