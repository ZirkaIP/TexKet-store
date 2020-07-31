using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace Common.Interfaces.Services
{
	public interface ILaptopService
	{
		Task<IEnumerable<Laptop>> GetAllLaptopsAsync();
		Task<Laptop> GetLaptopById(int id);
		Task<Laptop> CreateLaptop(Laptop newLaptop);
		Task UpdateLaptop(Laptop laptopToBeUpdated, Laptop laptop);
		Task DeleteLaptop(Laptop laptop);
	}
}
