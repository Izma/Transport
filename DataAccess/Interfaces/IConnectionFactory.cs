using System.Data.SqlClient;

namespace DataAccess.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection Connection { get; }
    }
}
