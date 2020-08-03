using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TexKet_store.Resources
{
	public class SmartphoneResource
	{
		public Guid Id { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public int AvailableQuantity { get; set; }

		public int Price { get; set; }
	}
}
