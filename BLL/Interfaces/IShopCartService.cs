using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using Common.Models;

namespace BLL.Interfaces
{
	public interface IShopCartService
	{
		public ValueTask<Product> GetProductById(Guid id);

		public Task AddToCart(Product product, int amount);

		public List<ShopCartItem> GetCartItems();
	}
}