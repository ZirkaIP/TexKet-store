using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Entities;
using Common.Interfaces;

namespace BLL.Services
{
	 public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			var productsList = _unitOfWork.Products.GetAllAsync();
			return await  productsList;
		}


	}

}
