using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Entities;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace TexKet_store.Controllers
{

	public class OrderController : Controller

    {
	    private readonly Order _order= new Order();
	    private readonly IOrderService _orderService;
	    public OrderController(IOrderService orderService)
	    {
		    _orderService = orderService;
	    }

        public IActionResult Checkout()
        {
            return View();
        }

		 [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
	        var orderResult = await _orderService.Create(_order);
	        return View(orderResult);
        }
	}
}