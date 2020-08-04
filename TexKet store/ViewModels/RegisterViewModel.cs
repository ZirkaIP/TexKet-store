using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TexKet_store.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(dataType:DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "Password and password confirmation fields doesn't match")]
		public string ConfirmPassword { get; set; }

	}
}
