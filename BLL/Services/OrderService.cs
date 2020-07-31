using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Common.Entities;
using BLL.Interfaces;
using Common.Interfaces;
using Microsoft.Data.SqlClient;

namespace BLL.Services
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;

		public async Task<OrderDetails> Create(Guid productId, uint productAmount, string userAddress)
		{
			try
			{
				Order order = null;
				await using (var transaction = _unitOfWork.BeginTransaction())
				{
					var laptopsRepo = _unitOfWork.Laptops;
					var laptop = laptopsRepo.FindBy(l => l.Id == productId).FirstOrDefault();
					laptop.AvailableQuantity -= (int) productAmount;

					await laptopsRepo.UpdateAsync(new[] {laptop});

					order = new Order()
					{
						OrderId = Guid.NewGuid(),
						Amount = (int) productAmount,
						UserAdress = userAddress
					};

					await _unitOfWork.Orders.AddAsync(order);
					await transaction.CommitAsync();
				}

				return new OrderDetails()
				{
					Success = true,
					Order = order
				};
			}
			catch (SqlException e) when (e.Number == 127)
			{
				return new OrderDetails()
				{
					Error = "All products have been sold",
					Success = false
				};
			}
			catch (Exception e)
			{
				return new OrderDetails()
				{
					Error = "Oops we have a problem",
					Success = false
				};
			}
		}
	}
}
