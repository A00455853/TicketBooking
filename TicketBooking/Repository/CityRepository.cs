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

       
    }
}
