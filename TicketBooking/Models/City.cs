namespace TicketBooking.Models
{
    public class City
    {
        public int Id { get; protected set; }
        public string? CityName { get; protected set; }
        public bool IsActive { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public IEnumerable<City>? Cities { get; set; }

        public City(int id, string? cityName, bool isActive, bool isDeleted)
        {
            this.Id = id;
            this.CityName = cityName;
            this.IsActive = isActive;
            this.IsDeleted = isDeleted;
        }

        public City()
        {

        }
    }
}
