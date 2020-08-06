using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Common.Models
{
	public class ShopCartItem
	{
		public Guid Id { get; set; }
		public decimal Price { get; set; }
		public Laptop Laptop { get; set; }
		public Camera Camera { get; set; }
		public Smartphone Smartphone { get; set; }

		public int  ShopCartId { get; set; }

	}
}
