using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Entities;
using Common.Interfaces;
using DAL.DataContext;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using TexKet_store.ViewModels;

namespace TexKet_store.Controllers
{
	
	public class HomeController : Controller

	{
		private readonly IProductService _productService;

		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var homeProducts = new HomeViewModel
			{
				ProductsList =  await _productService.GetAllProducts()
			};
			return View(homeProducts);
		}
	}
}
