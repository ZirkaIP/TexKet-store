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

	public class HomeController : Controller

	{
		private readonly OrderRequest _orderRequest =new OrderRequest();
		private readonly IOrderService _orderService;
		public HomeController( IOrderService orderService)
		{
			_orderService = orderService;
		}
		public async Task<IActionResult> Index()
		{
			var orderResult = await _orderService.Create(_orderRequest.ProductId, _orderRequest.ProductAmount,
				_orderRequest.UserAddress);
			return View(orderResult);
		}
	}
}
