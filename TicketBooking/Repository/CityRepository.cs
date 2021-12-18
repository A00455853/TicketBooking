using System.Data;
using TicketBooking.IRepository;
using TicketBooking.Models;
using Dapper;
namespace TicketBooking.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly IDapperRepository dapperRepository;
        public CityRepository(IDapperRepository iDapperRepository)
        {
            dapperRepository = iDapperRepository;
        }
        public IEnumerable<City> GetCities()
        {
            return dapperRepository.Execute<City>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "[dbo].[GetCityList]", DynamicParameters = null }).ToList();
        }

        public IEnumerable<CityMovie> GetCityMovie(int cityId)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CityId", cityId);
            return dapperRepository.Execute<CityMovie>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "[dbo].[GetMovieList]", DynamicParameters = dynamicParameters }).ToList();
        }

        public IEnumerable<MovieTimes> GetMovieTimes()
        {
            var dynamicParameters = new DynamicParameters();

            return dapperRepository.Execute<MovieTimes>(new DapperProperty() { CommandType = CommandType.Text, ProcName = "Select Id,   MovieTime from movieTimes", DynamicParameters = dynamicParameters }).ToList();
        }

        public IEnumerable<TheatreListByMovie> TheatreListByMovie(int movieId)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MovieId", movieId);
            return dapperRepository.Execute<TheatreListByMovie>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "TheatreListByMovieId", DynamicParameters = dynamicParameters }).ToList();
        }

        public MovieBookingDetails GetMovieBookingDetails(int movieId, int theatreId, int cityId, int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MovieId", movieId);
            dynamicParameters.Add("@TheatreId", theatreId);
            dynamicParameters.Add("@CityId", cityId);
            dynamicParameters.Add("@Id", id);
            return dapperRepository.Execute<MovieBookingDetails>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "GetMovieBookingDetails", DynamicParameters = dynamicParameters }).FirstOrDefault();
        }

        public IEnumerable<TheatreBookedSeats> GetTheatreBookedSeats(int movieId, int theatreId, int cityId, DateTime bookingDate)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MovieId", movieId);
            dynamicParameters.Add("@TheatreId", theatreId);
            dynamicParameters.Add("@CityId", cityId);
            dynamicParameters.Add("@BookingDate", bookingDate);

            return dapperRepository.Execute<TheatreBookedSeats>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "GetTheatreBookedSeats", DynamicParameters = dynamicParameters }).ToList();
        }

        public int SaveMovieBooking(MovieBookingDetails movieBookingDetails)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerName", movieBookingDetails.CustomerName);
            dynamicParameters.Add("@EmailAddress", movieBookingDetails.CustomerEmailAddress);
            dynamicParameters.Add("@MobileNumber", movieBookingDetails.CustomerMobile);
            dynamicParameters.Add("@BookingDate", movieBookingDetails.SelectedDateTime);
            dynamicParameters.Add("@ShowTime", movieBookingDetails.ShowTime);
            dynamicParameters.Add("@TicketPrice", movieBookingDetails.TicketPrice);
            dynamicParameters.Add("@TotalTicket", movieBookingDetails.strTicketNumbers.Split(',').Count());
            dynamicParameters.Add("@TotalAmount", movieBookingDetails.strTicketNumbers.Split(',').Count() * movieBookingDetails.TicketPrice);
            dynamicParameters.Add("@SelectedTickets", movieBookingDetails.strTicketNumbers);
            dynamicParameters.Add("@TheatreId", movieBookingDetails.TheatreId);
            dynamicParameters.Add("@CityId", movieBookingDetails.CityId);
            dynamicParameters.Add("@MovieId", movieBookingDetails.MovieId);
            dynamicParameters.Add("@PaymentType", movieBookingDetails.strCreditCardType);
            dynamicParameters.Add("@CardNumber", movieBookingDetails.CreditCardNumber);
            dynamicParameters.Add("@ExpiryDate", movieBookingDetails.ExpiryDate);

            var result = dapperRepository.Execute<dynamic>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "SaveTicketBooking", DynamicParameters = dynamicParameters }).ToList();
            return result.FirstOrDefault().CustomerId;

        }

        public MovieBookingDetails GetMovieBookingDetails(int CustomerId)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerBookingDetailId", CustomerId);

            return dapperRepository.Execute<MovieBookingDetails>(new DapperProperty() { CommandType = CommandType.StoredProcedure, ProcName = "GetMovieDetails", DynamicParameters = dynamicParameters }).FirstOrDefault();
        }


    }
}
