using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FoodPool.Core.Data.Services
{
    public interface IStallManager
    {
		Task<List<Stall>> FindAllAsync();
		Task<Stall> FindByIdAsync(string id);
		Task<List<Stall>> FindByNameAsync(string name);
		Task SaveAsync(Stall stall);
        Task DeleteAsync(Stall stall);
    }
}
