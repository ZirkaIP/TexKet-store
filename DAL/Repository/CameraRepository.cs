using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using DAL.DataContext;
using DAL.Interfaces;

namespace DAL.Repository
{
	public class CameraRepository : Repository<Camera>, ICameraRepository
	{
		public CameraRepository(DatabaseContext context) : base(context)
		{
		}
		public DatabaseContext DatabaseContext => Context as DatabaseContext;

		public IEnumerable<Camera> GetCheapCameras()
		{
			return DatabaseContext.Cameras.OrderBy(p => p.Price).ToList();
		}
	}
}
