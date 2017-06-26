using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodPool.Core;

namespace FoodPool.Core
{
    public interface IStallStore
    {
        Task<List<Stall>> FindAllAsync();
		Task<Stall> FindByIdAsync(string id);
        Task<List<Stall>> FindByNameAsync(string name);
        Task SaveAsync(Stall stall);
		Task DeleteAsync(Stall stall);
    }
}
