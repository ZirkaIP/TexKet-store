using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public void AddToCart(Laptop laptop, int amount)
		{
			ShopCartItem cartItem = new ShopCartItem()
			{
				ShopCartId = cart.CartId,
				Laptop = laptop,
				Price = laptop.Price
			};

			_unitOfWork.ShopCartItems.AddAsync(cartItem);

		}

		public List<ShopCartItem> GetCartItems()
		{
			return _unitOfWork.ShopCartItems.FindBy(c => c.ShopCartId == cart.CartId).Include(s => s.Laptop).ToList();
		}
	}
}
