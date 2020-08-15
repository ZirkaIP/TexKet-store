using System.Threading.Tasks;
using Common.Entities;

namespace BLL.Interfaces
{
	public interface IOrderService
	{
		Task<Order> Create(Order order);
	}
}