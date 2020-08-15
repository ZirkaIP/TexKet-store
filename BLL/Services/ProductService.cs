using System;
using System.Collections.Generic;
using System.Linq;
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
			var productsList =  await _unitOfWork.Products.GetAllAsync();
			return  productsList;
		}

		public IEnumerable<Product> GetCategoryProducts(string category)
		{
			//var productCategory = 
			//if (string.Equals(, category, StringComparison.OrdinalIgnoreCase))
			//{
			//	laptops = allLaptops.Laptops.Where(i => i.Category.CategoryName.Equals("Xiaomi")).OrderBy(i => i.Price);
			//}

			var categoryProducts = _unitOfWork.Products
				.FindBy(i => i.Category.CategoryName.Equals(category));

			var categoryProductsList = categoryProducts.ToList();
			return  categoryProductsList;
		}

	}

}
