﻿using Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBusRepository
    {
        Task<int> AddBus(BusModel model);
        Task<IQueryable<BusModel>> GetBuses();
    }
}
