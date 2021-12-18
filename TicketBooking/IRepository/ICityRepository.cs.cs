using TicketBooking.Models;

namespace TicketBooking.IRepository
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
        IEnumerable<CityMovie> GetCityMovie(int cityId);
        IEnumerable<MovieTimes> GetMovieTimes();
        IEnumerable<TheatreListByMovie> TheatreListByMovie(int movieId);
        MovieBookingDetails GetMovieBookingDetails(int movieId, int theatreId, int cityId, int id);
        IEnumerable<TheatreBookedSeats> GetTheatreBookedSeats(int movieId, int theatreId, int cityId, DateTime bookingDate);
        int SaveMovieBooking(MovieBookingDetails movieBookingDetails);

        MovieBookingDetails GetMovieBookingDetails(int CustomerId);


    }
}
