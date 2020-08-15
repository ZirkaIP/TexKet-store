using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Entities
{
	public sealed class Order 
	{
		public Guid OrderId { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderTime { get; set; }

		public int Amount { get; set; }

		[Display(Name = "Enter your name")]
		[MinLength(2,ErrorMessage = "Name should be longer than 1 letter")]
		public string FirstName { get; set; }

		[Display(Name = "Enter your surname")]
		[MinLength(2, ErrorMessage = "Surname should be longer than 1 letter")]
		public string LastName { get; set; }

		[Display(Name = "Enter your e-mail")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display (Name = "Enter your phone number")]
		[MinLength(5,ErrorMessage = "Your phone number is too short")]
		public string PhoneNumber { get; set; }

		[Display(Name ="Enter your full home address")]
		[MinLength(10, ErrorMessage = "Huh, it should be longer")]
		public string UserAddress { get; set; }

		public string OrderStatus { get; set; }
	}
}
