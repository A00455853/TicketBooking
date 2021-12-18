using Dapper;
using TicketBooking.Models;
namespace TicketBooking.IRepository
{
    public interface IDapperRepository
    {
        IEnumerable<T> Execute<T>(DapperProperty dapperProperty) where T : class;
        void Execute(DapperProperty dapperProperty);
    }
}
