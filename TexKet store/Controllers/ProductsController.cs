using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using TexKet_store.ViewModels;

namespace TexKet_store.Controllers
{
	
    public class ProductsController : Controller
    {
	    private readonly IProductService _productService;

	    public ProductsController(IProductService productService)
	    {
		    _productService = productService;
	    }

	    [Route("products/list/{category}")]
        public async Task<ViewResult> List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string currCategory = String.Empty;
            if (string.IsNullOrEmpty(category))
            {
                products = await  _productService.GetAllProducts();
            }
            else
            {
               // if (string.Equals("laptops", category, StringComparison.OrdinalIgnoreCase))
                //{
	                products = _productService.GetCategoryProducts(category);
               /* }
                else

                 if (string.Equals("cameras", category, StringComparison.OrdinalIgnoreCase))
                {
	                products = allLaptops.Laptops.Where(i => i.Category.CategoryName.Equals("Cameras")).OrderBy(i => i.Price);
                }
                else if (string.Equals("camera", category, StringComparison.OrdinalIgnoreCase))
                {
	                products = allLaptops.Laptops.Where(i => i.Category.CategoryName.Equals("Cameras")).OrderBy(i => i.Price);
                } */
                currCategory = _category;
            }

            var lapObj = new ProductsListViewModel
            {
                AllProducts= products,
                CurrentCategory = currCategory
            };

            ViewBag.Title = "Laptops page";

            return View(lapObj);
        }
    }
}