using System;
using Microsoft.AspNetCore.Identity;

namespace Common.Users.Models
{
	public class AppUser : IdentityUser<Guid>
	{
		public string FirstName { get; set; }

		public string Lastname { get; set; }

	}
}
