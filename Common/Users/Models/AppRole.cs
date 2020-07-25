using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace Common.Users.Models
{
	public class AppRole : IdentityRole<Guid>
	{
	}
}
