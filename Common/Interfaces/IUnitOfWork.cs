using System;
using Common.Entities;
using Common.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Product> Products{ get; }
		IGenericRepository<Order> Orders { get; }
		IGenericRepository<ShopCartItem> ShopCartItems { get; }

		public IDbContextTransaction BeginTransaction();

	}
}
