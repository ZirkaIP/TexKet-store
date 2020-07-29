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
			Cameras = new  CameraRepository(_context);
			Smartphones = new SmartphoneRepository(_context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public ILaptopsRepository Laptops { get; set; }
		public ICameraRepository Cameras { get; set; }
		public ISmartPhonesRepository Smartphones { get; set; }
	}
}
