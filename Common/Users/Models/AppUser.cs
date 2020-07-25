using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Common.Users.Models
{
	public class AppUser : IdentityUser<Guid>
	{
		
	}
}
