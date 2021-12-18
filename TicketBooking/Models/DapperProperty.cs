using Dapper;
using System.Data;

namespace TicketBooking.Models
{
    public class DapperProperty
    {
        public string? ProcName { get; set; }

        public DynamicParameters? DynamicParameters { get; set; }

        public CommandType CommandType { get; set; }
    }
}
