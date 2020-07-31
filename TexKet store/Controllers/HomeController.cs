using System;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Interfaces;
using DAL.DataContext;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using TexKet_store.ViewModels;

namespace TexKet_store.Controllers
{
	public class OrderRequest
	{
		public Guid ProductId { get; set; }
		public string UserAddress { get; set; }
		public uint ProductAmount { get; set; }
	}

	public class HomeController:Controller
	{
		public async Task<IActionResult> Index(
		
			[FromServices] IOrderService orderService,
			[FromBody] OrderRequest orderRequest
			)
		{
			var orderResult = await orderService.Create(orderRequest.ProductId, orderRequest.ProductAmount,
				orderRequest.UserAddress);
			return View(orderResult);
		}
	}
}
