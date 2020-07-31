using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class Smartphone
	{
		public Guid Id { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public int AvailableQuantity { get; set; }

		public int Price { get; set; }

		public int CategoryId { get; set; }
	}
}
