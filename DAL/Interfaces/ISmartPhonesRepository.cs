using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace DAL.Interfaces
{
	public interface ISmartPhonesRepository
	{
		IEnumerable<Smartphone> GetCheapSmartPhones();
	}
}
