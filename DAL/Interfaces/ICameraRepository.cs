using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace DAL.Interfaces
{
	public interface ICameraRepository
	{
		/// <summary>
		/// Returns cheap laptops first
		/// </summary>
		/// <returns></returns>
		IEnumerable<Camera> GetCheapCameras();
	}
}
