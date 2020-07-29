using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		ILaptopsRepository Laptops { get; }
		ICameraRepository Cameras { get; }
		ISmartPhonesRepository Smartphones { get; }
		
		int Complete();
	}
}
