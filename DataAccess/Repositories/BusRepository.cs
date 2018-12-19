using Dapper;
using DataAccess.Interfaces;
using Entities;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BusRepository : BaseRepository, IBusRepository
    {
        public BusRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<int> AddBus(BusModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@number", model.Number, DbType.String, ParameterDirection.Input, 10);
            parameters.Add("@color", model.Color, DbType.String, ParameterDirection.Input, 100);
            parameters.Add("@model", model.Model, DbType.String, ParameterDirection.Input, 10);
            parameters.Add("@seatNumber", model.SeatNumber, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@wheelsNumber", model.WheelsNumber, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@engineNumber", model.EngineNumber, DbType.String, ParameterDirection.Input, 100);
            parameters.Add("@userRegister", model.UserRegister, DbType.String, ParameterDirection.Input, 50);
            return await WithConnection(async c => await c
                .ExecuteAsync(sql: "[dbo].[spAddBus]", param: parameters, commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<IQueryable<BusModel>> GetBuses()
        {
            var result = await WithConnection(async c => await c.QueryAsync<BusModel>(sql: "[dbo].[spGetBuses]", param: null, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ConfigureAwait(false);
            return result.AsQueryable();
        }
    }
}
