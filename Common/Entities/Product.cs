using System;

namespace Common.Entities
{
	public class Product
	{
		public Guid ProductId { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public decimal Price { get; set; }

		public int AmountAvailable { get; set; }

		public virtual Category Category { get; set; }
	}
}
