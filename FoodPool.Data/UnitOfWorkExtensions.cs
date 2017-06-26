using System;
using FoodPool.Core;

namespace FoodPool.Data
{
    public static class UnitOfWorkExtensions
    {
        public static FoodPoolContext DbContext(this IUnitOfWork unitOfWork)
		{
			return (FoodPoolContext)unitOfWork.Context;
		}
    }
}
