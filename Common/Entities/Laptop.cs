﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities
{
	public class Laptop
	{	
		[Key]
		public int Id { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public bool IsAvailable { get; set; }

		public int Price { get; set; }

		public int CategoryId { get; set; }
	}
}
