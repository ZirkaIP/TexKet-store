using System;
using Common.Entities;

namespace Common.Models
{
	public class OrderDetails
	{
		
		public Guid Id { get; set; }

		public decimal  Price { get; set; }

		public Guid OrderId { get; set; }

		public Guid ProductId { get; set; }

		public virtual Product Product { get; set; }

		public virtual Order Order { get; set; }

		public string OrderResult { get; set; }
		
	}
}
