using System.Collections.Generic;
using Common.Entities;
using Common.Models;

namespace BLL.Interfaces
{
	public interface IShopCartService
	{
		void AddToCart(Laptop laptop, int amount);

		public List<ShopCartItem> GetCartItems();
	}
}