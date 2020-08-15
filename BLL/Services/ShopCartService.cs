using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Entities;
using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
	public class ShopCartService : IShopCartService
	{
		private readonly IUnitOfWork _unitOfWork;
		readonly ShopCart cart = new ShopCart();

		public ShopCartService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void AddToCart(Product product, int amount)
		{
			ShopCartItem cartItem = new ShopCartItem()
			{
				ShopCartId = cart.CartId,
				Product = product,
				Price = product.Price
			};

			_unitOfWork.ShopCartItems.AddAsync(cartItem);
		}

		public async  ValueTask<Product> GetProductById(Guid id)
		{
			return await _unitOfWork.Products.GetByIdAsync(id);
		}

		public List<ShopCartItem> GetCartItems()
		{
			return _unitOfWork.ShopCartItems.FindBy(c => c.ShopCartId == cart.CartId).Include(s => s.Product).ToList();
		}
	}
}
