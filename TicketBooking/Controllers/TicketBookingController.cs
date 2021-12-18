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

       
    }
}
