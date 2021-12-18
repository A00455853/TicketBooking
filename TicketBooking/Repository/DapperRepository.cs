using Dapper;
using System.Data;
using TicketBooking.IRepository;
using TicketBooking.Models;

namespace TicketBooking.Repository
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IDbConnection dbConnection;
        public DapperRepository(IDbConnection iDbConnection)
        {
            dbConnection = iDbConnection;
        }
        public IEnumerable<T> Execute<T>(DapperProperty dapperProperty) where T : class
        {
            var result = dbConnection.Query<T>(dapperProperty.ProcName, dapperProperty.DynamicParameters, null, true, null, dapperProperty.CommandType);
            return result;
        }
        public void Execute(DapperProperty dapperProperty)
        {
            dbConnection.Execute(dapperProperty.ProcName, dapperProperty.DynamicParameters, null, null, dapperProperty.CommandType);
        }
    }
}
