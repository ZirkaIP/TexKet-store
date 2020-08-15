using System;
using Common.Entities;

namespace Common.Models
{
	public class ShopCartItem
	{
		public Guid Id { get; set; }

		public decimal Price { get; set; }

		public Product Product { get; set; }

		public Guid ShopCartId { get; set; }

	}
}
