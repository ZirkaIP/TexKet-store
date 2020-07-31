using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities
{
	public class Laptop
	{
		public Guid Id { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public  int AvailableQuantity { get; set; }

		public decimal Price { get; set; }

		public int CategoryId { get; set; }
	}
}
