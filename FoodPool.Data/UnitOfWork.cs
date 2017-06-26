using System;
using System.Threading.Tasks;
using FoodPool.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodPoolContext _context;

        public UnitOfWork(FoodPoolContext context)
        {
            _context = context;
        }

        public object Context => _context;

        public bool IsDisposed { get; private set; }

        public void Delete<TModel>(TModel entity) where TModel : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("UnitofWork already disposed.");

            _context.Dispose();
            IsDisposed = true;
            }

        public Task Reload<T>(T entity) where T : class
        {
            return _context.Entry(entity).ReloadAsync();
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void Add<TModel>(TModel entity) where TModel : class, IModel
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                if (string.IsNullOrEmpty(entity.Id))
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entry.State = EntityState.Added;
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}
