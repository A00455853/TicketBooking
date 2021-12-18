namespace TicketBooking.Models
{
    public class CityMovie
    {
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public string? MovieImagePath { get; set; }

        public IEnumerable<CityMovie>? lstCityMovie { get;set; }
    }
}
