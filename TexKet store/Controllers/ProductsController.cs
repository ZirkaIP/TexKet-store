using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TexKet_store.Controllers
{
    public class ProductsController : Controller
    {
	    private readonly IProductService _productService;

	    public ProductsController(IProductService productService)
	    {
		    _productService = productService;
	    }

        public IActionResult List()
        {

            return View();
        }
    }
}