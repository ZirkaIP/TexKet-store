using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class ShopCart
	{
		public int CartId { get; set; }

		public List<ShopCartItem> ToPayList { get; set; }
	}
}
