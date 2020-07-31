using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Common.Models
{
	public class OrderDetails
	{
		public Order Order { get; set; }

		public string Error { get; set; }

		public bool Success { get; set; }
	}
}
