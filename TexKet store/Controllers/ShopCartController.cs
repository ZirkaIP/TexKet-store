using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using TexKet_store.ViewModels;

namespace TexKet_store.Controllers
{
    public class ShopCartController : Controller
    {
	    private readonly IShopCartService _shopCartService;
	    private readonly ShopCart _shopCart = new ShopCart();

	    public ShopCartController(IShopCartService shopCartService)
	    {
		    _shopCartService = shopCartService;
	    }
        public ViewResult ShopCart()
        {
	        var items = _shopCartService.GetCartItems();
	        _shopCart.ToPayList = items;

	        var obj = new ShopCartViewModel
	        {
		        Cart = _shopCart
	        };
	        return View(obj);

        }
    }
}