using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using DAL.DataContext;
using DAL.Interfaces;

namespace DAL.Repository
{
	public class UnitOfWork  : IUnitOfWork
	{
		private readonly DatabaseContext _context;

		public UnitOfWork(DatabaseContext context)
		{
			_context = context;
			Laptops = new LaptopsRepository(_context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
		public ILaptopsRepository Laptops { get; set; }
	}
}
