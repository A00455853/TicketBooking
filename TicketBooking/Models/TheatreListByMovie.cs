namespace TicketBooking.Models
{
    public class TheatreListByMovie
    {
        public int TheatreId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieImagePath { get; set; }
        public string TheatreName { get; set; }
    }
}
