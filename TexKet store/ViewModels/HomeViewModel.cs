using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TexKet_store.DAL.Models;
using TexKet_store.ViewModels;

namespace TexKet_store.ViewModels
{
	public class HomeViewModel
	{
		private IEnumerable<Laptop> FavoriteLaptops { get; set; }
	}
}
