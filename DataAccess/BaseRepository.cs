using DataAccess.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class BaseRepository
    {
        private readonly IConnectionFactory factory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            factory = connectionFactory;
        }

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var cn = factory.Connection)
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    return await getData(cn).ConfigureAwait(false);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }


    }
}
