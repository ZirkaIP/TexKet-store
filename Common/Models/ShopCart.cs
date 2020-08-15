using System;
using System.Collections.Generic;

namespace Common.Models
{
	public class ShopCart
	{
		public Guid CartId { get; set; }

		public List<ShopCartItem> ToPayList { get; set; }
	}
}
