using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TexKet_store.Resources;
using TexKet_store.Settings;
using TexKet_store.ViewModels;

namespace TexKet_store.Controllers
{
	public class AuthController : Controller
	{
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly JwtSettings _jwtSettings;


		public AuthController(IMapper mapper,
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			SignInManager<AppUser> signInManager,
			IOptionsSnapshot<JwtSettings> jwtSettings)
		{
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_jwtSettings = jwtSettings.Value;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{

				var user = new AppUser
				{
					UserName = model.Email,
					Email = model.Email
				};
				var createResult = await _userManager.CreateAsync(user, model.Password);
				if (createResult.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("index", "Home");
				}

				foreach (var error in createResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("index", "Home");
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
	
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			var user = _userManager.Users.SingleOrDefault(u => u.UserName == model.Email);
			if (user is null)
			{
				return NotFound("User not found");
			}

			var userSigninResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

			if (userSigninResult.Succeeded)
			{
				var roles = await _userManager.GetRolesAsync(user);
				return RedirectToAction("index", "home");
			}

			ModelState.AddModelError(String.Empty, "Login or Password is incorrect");
			return View(model);
		}



		[HttpPost("Roles")]
		public async Task<IActionResult> CreateRole(string roleName)
		{
			if (string.IsNullOrWhiteSpace(roleName))
			{
				return BadRequest("Role name should be provided.");
			}

			var newRole = new AppRole
			{
				Name = roleName
			};

			var roleResult = await _roleManager.CreateAsync(newRole);

			if (roleResult.Succeeded)
			{
				return Ok();
			}

			return Problem(roleResult.Errors.First().Description, null, 500);
		}

		[HttpPost("User/{userEmail}/Role")]
		public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
		{
			var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

			var result = await _userManager.AddToRoleAsync(user, roleName);

			if (result.Succeeded)
			{
				return Ok();
			}

			return Problem(result.Errors.First().Description, null, 500);
		}
		private string GenerateJwt(AppUser user, IList<string> roles)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
			};

			var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
			claims.AddRange(roleClaims);

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

			var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Issuer,
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}