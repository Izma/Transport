using Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IBus
    {
        Task<int> SaveBus(BusModel model);
        Task<IQueryable<BusModel>> GetBuses();
    }
}
