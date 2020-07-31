using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace Common.Interfaces.Services
{
	public interface ISmartphoneService
	{
		Task<IEnumerable<Smartphone>> GetAllSmartphonesAsync();
		Task<Smartphone> GetSmartphoneById(int id);
		Task<Smartphone> CreateSmartphone(Smartphone newSmartphone);
		Task UpdateSmartphone(Smartphone smartphoneToBeUpdated, Smartphone smartphone);
		Task DeleteSmartphone(Smartphone smartphone);
	}
}
