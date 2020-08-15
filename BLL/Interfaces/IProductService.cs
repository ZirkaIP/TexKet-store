using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;

namespace BLL.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAllProducts();

		IEnumerable<Product> GetCategoryProducts(string category);
	}
}