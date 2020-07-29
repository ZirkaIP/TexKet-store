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
		private DatabaseContext _context;

		public HomeController(IUnitOfWork unitOfWork,DatabaseContext context)
		{
			_UoW = unitOfWork;
			_context = context;
		}
		
		public IActionResult Index()
		{
			LaptopsRepository laps = new LaptopsRepository(_context);
			var homeLaptops = new HomeViewModel
			{
				Laptops = laps.GetAll()
			};
			;
			return View(homeLaptops);
		}
	}
}
