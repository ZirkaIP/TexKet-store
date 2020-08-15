using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Entities;
using Common.Interfaces;
using Common.Models;
using Microsoft.Data.SqlClient;

namespace BLL.Services
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly  ShopCart shopCart = new ShopCart();

		public OrderService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Order> Create(Order order)
		{
			try
			{
				order.OrderTime = DateTime.Now;

				var productsRepo = _unitOfWork.Products;

				await using (var transaction = _unitOfWork.BeginTransaction())
				{
					var items = shopCart.ToPayList;
					foreach (var item in items)
					{
						var orderDetail = new OrderDetails()
						{
							ProductId  = item.Product.ProductId,
							OrderId = order.OrderId,
							Price = item.Product.Price
						};
						var product = productsRepo.FindBy(l => l.ProductId == item.Product.ProductId ).FirstOrDefault();
						product.AmountAvailable -= (int)order.Amount;
						await productsRepo.UpdateAsync(new[] { product });
					}
					

					order = new Order()
					{
						OrderId = Guid.NewGuid(),
						Amount = (int) order.Amount,
						UserAddress = order.UserAddress,
						OrderStatus = "Succeed"
					};

					await _unitOfWork.Orders.AddAsync(order);
					await transaction.CommitAsync();
				}

				return order;
			}
			catch (SqlException e) when (e.Number == 127)
			{
				 new OrderDetails()
				{
					OrderResult = "All products have been sold",
					OrderId = order.OrderId
				};
				 return new Order()
				 {
					 OrderId = Guid.NewGuid(),
					 Amount = (int)order.Amount,
					 UserAddress = order.UserAddress,
					 OrderStatus = "Failed"
				 };
			}
			catch (Exception e)
			{
				 new OrderDetails()
				{
					OrderResult = "Oops we have a problem",
					OrderId = order.OrderId
					
				};

				return new Order()
				{
					OrderStatus = "Failed",
					OrderId = Guid.NewGuid(),
					Amount = (int)order.Amount,
					UserAddress = order.UserAddress
				};
			}
		}
	}
}
