﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using TexKet_store.ViewModels;

namespace TexKet_store.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Laptop>  Laptops { get; set; }
	}
}