using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TexKet_store.Resources
{
	public class LaptopResource
	{
		public Guid LaptopId { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public int AvailableQuantity { get; set; }

		public decimal Price { get; set; }
	}
}
