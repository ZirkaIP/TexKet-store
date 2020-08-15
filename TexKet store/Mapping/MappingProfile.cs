using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Entities;
using Common.Users.Models;
using TexKet_store.Resources;

namespace TexKet_store.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			
			CreateMap<UserSignUpResource, AppUser>()
				.ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
		}
	}
}
