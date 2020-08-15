using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;

namespace TexKet_store.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<Product> AllProducts { get; set; }

		public string CurrentCategory { get; set; }
	}
}
