using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Core
{
    public class Bus : IBus
    {
        private readonly IBusRepository repository;

        public Bus(IBusRepository busRepository)
        {
            repository = busRepository;
        }

        public async Task<IQueryable<BusModel>> GetBuses()
        {
            return await repository.GetBuses().ConfigureAwait(false);
        }

        /// <summary>
        /// Method for save a new bus information
        /// </summary>
        /// <param name="model">BusModel Class <see cref="BusModel"/></param>
        /// <returns></returns>
        public async Task<int> SaveBus(BusModel model)
        {
            return await repository.AddBus(model).ConfigureAwait(false);
        }
    }
}
