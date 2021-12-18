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


        [HttpGet("MovieSelection/{cityId}")]
        public IActionResult MovieSelection(int cityId)
        {
            CityMovie cityMovie = new CityMovie();
            cityMovie.lstCityMovie = this.cityRepository.GetCityMovie(cityId);
            return View(cityMovie);
        }

        //adding control to handle Movie Selection based on city

        [HttpGet("MovieSelection/{cityId}")]
        public IActionResult MovieSelection(int cityId)
        {
            CityMovie cityMovie = new CityMovie();
            cityMovie.lstCityMovie = this.cityRepository.GetCityMovie(cityId);
            return View(cityMovie);
        }

        // adding control to handle Theatre Selection based on the selected movie

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

        //TODO: Add control to allow user to Book Movie Ticket
        //TODO: Add control to allow user to choose seats and complete the booking
    }
}
