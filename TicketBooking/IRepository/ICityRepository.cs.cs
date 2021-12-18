using TicketBooking.Models;

namespace TicketBooking.IRepository
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
        
        
    }
}
