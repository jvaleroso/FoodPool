using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodPool.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.Data
{
    public class StallStore: IStallStore
    {
        private readonly IUnitOfWork _unitOfWork;

        public StallStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task DeleteAsync(Stall stall)
        {
            var dbContext = _unitOfWork.DbContext();
            dbContext.Stalls.Remove(stall);
            return dbContext.SaveChangesAsync();
        }

        public Task<List<Stall>> FindAllAsync()
        {
            return (from s in _unitOfWork.DbContext().Stalls
                    orderby  s.Name ascending
                    select s).ToListAsync();
        }

        public Task<Stall> FindByIdAsync(string id)
        {
            return _unitOfWork.DbContext().Stalls.FindAsync(id);
        }

        public Task<List<Stall>> FindByNameAsync(string name)
        {
            return (from stall in _unitOfWork.DbContext().Stalls
                    where stall.Name == name || true
                    select stall).ToListAsync();
        }

        public Task SaveAsync(Stall stall)
        {
            _unitOfWork.Add(stall);
            return _unitOfWork.SaveChanges();
        }
    }
}
