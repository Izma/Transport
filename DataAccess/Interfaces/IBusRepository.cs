using Entities;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBusRepository
    {
        Task<int> AddBus(BusModel model);
    }
}
