using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace DAL.Interfaces
{
	public interface ILaptopsRepository
	{
		/// <summary>
		/// Returns cheap laptops first
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Laptop> GetCheapLaptops();
	}
}
