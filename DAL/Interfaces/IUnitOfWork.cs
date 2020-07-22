using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		ILaptopsRepository Laptops { get; }
		
		int Complete();
	}
}
