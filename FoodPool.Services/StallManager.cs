using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodPool.Core;
using FoodPool.Core.Data.Services;

namespace FoodPool.Services
{
    public class StallManager: IStallManager
    {
        private readonly IStallStore _stallStore;

        public StallManager(IStallStore stallStore)
        {
            _stallStore = stallStore;
        }

        public Task DeleteAsync(Stall stall)
        {
            return _stallStore.DeleteAsync(stall);
        }

        public Task<List<Stall>> FindAllAsync()
        {
            return _stallStore.FindAllAsync();
        }

        public Task<Stall> FindByIdAsync(string id)
        {
            return _stallStore.FindByIdAsync(id);
        }

        public Task<List<Stall>> FindByNameAsync(string name)
        {
            return _stallStore.FindByNameAsync(name);
        }

        public Task SaveAsync(Stall stall)
        {
            return _stallStore.SaveAsync(stall);
        }
    }
}
