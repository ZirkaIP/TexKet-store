using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using Common.Interfaces;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repository
{
	public class UnitOfWork  : IUnitOfWork
	{
		private readonly DatabaseContext _context;

		public UnitOfWork(DatabaseContext context)
		{
			_context = context;
			 Laptops = new Repository<Laptop>(_context);
			 Cameras = new  Repository<Camera>(_context);
			 Smartphones = new Repository<Smartphone>(_context);
		}

		public IGenericRepository<Laptop> Laptops { get; }

		public IGenericRepository<Camera> Cameras { get; }

		public IGenericRepository<Smartphone> Smartphones { get; }

		public IGenericRepository<Order> Orders { get; }

		public IDbContextTransaction BeginTransaction()
		{
			return _context.Database.BeginTransaction();
		}

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

	}
}
