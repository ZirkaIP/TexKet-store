using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using DAL.DataContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	class SmartphoneRepository : Repository<Smartphone>, ISmartPhonesRepository
	{
		public SmartphoneRepository(DbContext context) : base(context)
		{
		}

		public IEnumerable<Smartphone> GetCheapSmartPhones()
		{
			return DatabaseContext.SmartPhones.OrderBy(s => s.Price).ToList();
		}

		public DatabaseContext DatabaseContext => Context as DatabaseContext;
	}
}
