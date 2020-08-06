using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using Common.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Laptop> Laptops { get; }
		IGenericRepository<Camera> Cameras { get; }
		IGenericRepository<Smartphone> Smartphones { get; }
		IGenericRepository<Order> Orders { get; }
		IGenericRepository<ShopCartItem> ShopCartItems { get; }

		public IDbContextTransaction BeginTransaction();

	}
}
