using Microsoft.AspNetCore.Mvc;
using TicketBooking.IRepository;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class TicketBookingController : Controller
    {
        private readonly ICityRepository cityRepository;
        public TicketBookingController(ICityRepository iCityRepository)
        {
            this.cityRepository = iCityRepository;
        }
        [HttpGet("City")]
        public IActionResult City()
        {
            Models.City city = new Models.City();
            city.Cities = this.cityRepository.GetCities();
            return View(city);
        }

        [HttpGet("TheatreSelection/{Id}")]
        public IActionResult TheatreSelection(int Id)
        {
            var theatreSelection = new TheatreSelection();

            theatreSelection.TheatreListByMovie = this.cityRepository.TheatreListByMovie(Id);
            theatreSelection.MovieTimes = this.cityRepository.GetMovieTimes();
            theatreSelection.SelectedDate = DateTime.Now;
            theatreSelection.CityId = Id;
            return View(theatreSelection);
        }

        [HttpPost("PartialTheatreSelection")]
        public IActionResult PartialTheatreSelection(int Id, DateTime selectedDate)
        {
            var theatreSelection = new TheatreSelection();
            theatreSelection.TheatreListByMovie = this.cityRepository.TheatreListByMovie(Id);
            theatreSelection.MovieTimes = this.cityRepository.GetMovieTimes();
            theatreSelection.SelectedDate = selectedDate;
            theatreSelection.CityId = Id;
            return PartialView("_PartialTheatreSelection", theatreSelection);
        }

        [HttpGet("TicketBooking/{MovieId}/{TheatreId}/{CityId}/{Id}/{SelectedDate}")]
        public IActionResult TicketBooking(int MovieId, int TheatreId, int CityId, int Id, string SelectedDate)
        {
            MovieBookingDetails movieBookingDetails = this.cityRepository.GetMovieBookingDetails(MovieId, TheatreId, CityId, Id);
            movieBookingDetails.MovieId = MovieId;
            movieBookingDetails.TheatreId = TheatreId;
            movieBookingDetails.CityId = CityId;
            movieBookingDetails.ShowTimeId = Id;
            movieBookingDetails.SelectedDateTime = new DateTime(Convert.ToDateTime(SelectedDate).Year, Convert.ToDateTime(SelectedDate).Month, Convert.ToDateTime(SelectedDate).Day, movieBookingDetails.ShowTime.Hours, 0, 0);
            movieBookingDetails.TheatreBookedSeats = this.cityRepository.GetTheatreBookedSeats(MovieId, TheatreId, CityId, movieBookingDetails.SelectedDateTime);
            return View(movieBookingDetails);
        }

        [HttpGet("MovieSelection/{cityId}")]
        public IActionResult MovieSelection(int cityId)
        {
            CityMovie cityMovie = new CityMovie();
            cityMovie.lstCityMovie = this.cityRepository.GetCityMovie(cityId);
            return View(cityMovie);
        }

        [HttpPost("TicketBooking")]

        public IActionResult TicketBooking(MovieBookingDetails movieBookingDetails)
        {
            movieBookingDetails.CustomerName = movieBookingDetails.FirstName + " " + movieBookingDetails.LastName;
            movieBookingDetails.ExpiryDate = movieBookingDetails.strMonth + "/" + movieBookingDetails.strYear;
            var id = this.cityRepository.SaveMovieBooking(movieBookingDetails);
            return RedirectToAction("MovieTicket", new { CustomerId = id });
        }

        [HttpGet("MovieTicket/{CustomerId}")]
        public IActionResult MovieTicket(int CustomerId)
        {
            var movieDetails = this.cityRepository.GetMovieBookingDetails(CustomerId);
            return View(movieDetails);
        }
    }
}
