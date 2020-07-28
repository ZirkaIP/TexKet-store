using DAL.DataContext;
using DAL.Interfaces;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using TexKet_store.ViewModels;

namespace TexKet_store.Controllers
{
	public class HomeController:Controller
	{
		private readonly IUnitOfWork _UoW;

		public HomeController(IUnitOfWork unitOfWork)
		{
			_UoW = unitOfWork;
		}
		public IActionResult Index()
		{
			var homeLaptops = new HomeViewModel
			{
				Laptops = _UoW.Laptops.GetCheapLaptops()

			};
			;
			return View(homeLaptops);
		}
	}
}
