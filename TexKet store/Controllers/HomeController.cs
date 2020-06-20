using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace TexKet_store.Controllers
{
	public class HomeController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
