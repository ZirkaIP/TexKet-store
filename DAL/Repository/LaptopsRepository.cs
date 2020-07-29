using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using DAL.Interfaces;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using DAL.DataContext;

namespace DAL.Repository
{
	public class LaptopsRepository : Repository<Laptop>, ILaptopsRepository
	{
		public LaptopsRepository(DatabaseContext context) : base(context)
		{
		}

		public IEnumerable<Laptop> GetCheapLaptops()
		{
			return DatabaseContext.Laptops.OrderBy(p => p.Price).ToList();
		}

		public DatabaseContext DatabaseContext => Context as DatabaseContext;
	}
}
