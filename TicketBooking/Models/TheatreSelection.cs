namespace TicketBooking.Models
{
    public class TheatreSelection
    {
        public IEnumerable<TheatreListByMovie> TheatreListByMovie { get; set; }
        public IEnumerable<MovieTimes> MovieTimes { get; set; }
        public DateTime SelectedDate { get; set; }

        public int CityId { get; set; }
    }
}
