using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;

namespace Common.Entities
{
	public sealed class Order 
	{
		public Guid OrderId { get; set; }

		public int Amount { get; set; }

		public string UserAddress { get; set; }
	}
}
