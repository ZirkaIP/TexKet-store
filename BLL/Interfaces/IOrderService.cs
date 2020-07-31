using System;
using System.Threading.Tasks;
using Common.Models;

namespace BLL.Interfaces
{
	public interface IOrderService
	{
		Task<OrderDetails> Create(Guid productId, uint productAmount, string userAddress);
	}
}