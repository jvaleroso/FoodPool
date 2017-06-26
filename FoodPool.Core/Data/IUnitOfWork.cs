using System;
using System.Threading.Tasks;
using FoodPool.Core;

namespace FoodPool.Core
{
	public interface IUnitOfWork : IDisposable
	{
		object Context { get; }
		bool IsDisposed { get; }
		void Add<TModel>(TModel entity) where TModel : class, IModel;
		void Delete<TModel>(TModel entity) where TModel : class;
		Task SaveChanges();
		Task Reload<T>(T entity) where T : class;
	}
}
