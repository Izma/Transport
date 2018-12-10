using DataAccess.Interfaces;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class ConnectionFactory : IConnectionFactory
    {
        public readonly string connectionString;
        public ConnectionFactory(string connection)
        {
            connectionString = connection;
        }

        public SqlConnection Connection => new SqlConnection(connectionString);
    }
}
