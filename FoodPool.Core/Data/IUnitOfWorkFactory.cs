using System;
namespace FoodPool.Core
{
    public interface IUnitOfWorkFactory
    {
		IUnitOfWork Create();
	}
}
